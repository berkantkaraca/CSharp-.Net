using _43_API_EntityFramework.Contexts;
using _43_API_EntityFramework.Models;
using _43_API_EntityFramework.Models.DTOs;
using _43_API_EntityFramework.Models.Filters;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace _43_API_EntityFramework.Services
{
    public class ProductService : IProductService
    {
        //IoC olmasaydı her fonksiyonda bu şekilde oluşturma yapacaktık. Veya constructorda oluştursan alt metotlarda kullanılacktı. Her türlü performan açısından zararlı. IoC de newleme yaptık ve her yerde bu context nesnesini kullanacağız.
        //public void Add()
        //{
        //    AppContext context = new AppContext();
        //}

        private readonly AppDbContext _context;
        private readonly IMapper _mapper; //Automapper içim

        //Constructor IoC den contexti çeker ve referansını _contexte atar
        public ProductService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Task sadece void de kullanılır, dönüş tipini <> ekle
        //await: ana görevin bitmesini bekler
        public async Task<List<ProductReadDTO>> GetAllAsync()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();

            return _mapper.Map<List<ProductReadDTO>>(products);
        }

        public async Task<(ProductReadDTO? Dto, string? ETag)> GetByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
                return (null, null);

            var dto = _mapper.Map<ProductReadDTO>(product);  //product nesnesini ProductReadDTO çevirir

            var ETag = $"W/\"{Convert.ToBase64String(product.RowVersion)}\"";
            return (dto, ETag);
        }

        public async Task<PaginatedList<ProductReadDTO>> GetFilteredAsync(
            string? q, //search
            int? categoryId, 
            decimal? minPrice, 
            decimal? maxPrice, 
            string? sort, // name_asc, name_dex, price_asc, price_desc 
            int pageIndex, 
            int pageSize) //model binding daha hoş olurdu
        {
            //Sorguyu veritabanına atacağımdan IQueryable, eğer tüm dataları çekip işlem yapsaydım IEnumerable olurdu
            IQueryable<Product> query = _context.Products
                .Include(p => p.Category) //prductlarla birlikte categoryde gelsin
                .AsNoTracking(); //Categoryşe birleştirdik zaten. gelen datayla da işlem yapmıcam o yüzden trackingi kapadık

            if (!string.IsNullOrEmpty(q))
                query = query.Where(p => p.Name.Contains(q) || p.Description != null && p.Description.Contains(q));

            if (categoryId is not null)
                query = query.Where(p => p.CategoryId == categoryId);

            if (minPrice is not null)
                query = query.Where(p => p.Price >= minPrice);

            if (maxPrice is not null)
                query = query.Where(p => p.Price <= maxPrice);

            query = sort switch
            {
                "name_desc" => query.OrderByDescending(p => p.Name),
                "price_asc" => query.OrderBy(p => p.Price),
                "price_desc" => query.OrderByDescending(p => p.Price),
                _ => query.OrderBy(p => p.Name), // default: name_asc
            };

            var total = await query.CountAsync(); //ana query sorgusu daha gitmez. burda count için ayrı bir sorgu atar  
            var items = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<ProductReadDTO>(_mapper.ConfigurationProvider) //Projecto quaryble larda kullanılır. mapleme işlemini veritabanında yapar
                .ToListAsync(); //ana sorgu atılır

            return new PaginatedList<ProductReadDTO>(items, pageIndex, pageSize, total);
        }

        public async Task<(ProductReadDTO, string? ETag)> CreateAsync(ProductCreateDTO dto)
        {
            var product = _mapper.Map<Product>(dto);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            var ETag = $"W/\"{Convert.ToBase64String(product.RowVersion)}\"";
            var readDto = _mapper.Map<ProductReadDTO>(dto);

            return (readDto, ETag);
        }

        public async Task<string?> GetEtagAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
                return null;

            var ETag = $"W/\"{Convert.ToBase64String(product.RowVersion)}\"";
            return ETag;
        }

        public async Task<(bool Success, string ErrorCode)> UpdateAsync(int id, ProductUpdateDTO dto, string? ifMatchEtag)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return (false, "not_found");

            if (string.IsNullOrEmpty(ifMatchEtag))
                return (false, "etag_missing");

            var currentEtag = $"W/\"{Convert.ToBase64String(product.RowVersion)}\"";

            if (!string.Equals(currentEtag, ifMatchEtag.ToString(), StringComparison.Ordinal))
                return (false, "etag_mismatch");

            _mapper.Map(dto, product);
            await _context.SaveChangesAsync(); //takip edilen product olduğundan savechanges dememiz yeterli

            return (true, string.Empty);
        }

        public async Task<(bool Success, string ErrorCode)> PatchAsync(int id, JsonPatchDocument<ProductPatchDTO> patchDoc, string? ifMatchEtag)
        {
            if (patchDoc == null)
                return (false, "patch_null");

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return (false, "not_found");

            if (string.IsNullOrEmpty(ifMatchEtag))
                return (false, "etag_missing");

            var currentEtag = $"W/\"{Convert.ToBase64String(product.RowVersion)}\"";

            if (!string.Equals(currentEtag, ifMatchEtag.ToString(), StringComparison.Ordinal))
                return (false, "etag_mismatch");

            var patchDto = new ProductPatchDTO
            {
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Description = product.Description,
            };

            patchDoc.ApplyTo(patchDto);

            _mapper.Map(patchDto, product); //pageDto, producta çevirir
            await _context.SaveChangesAsync();
            return (true, string.Empty);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                return false;

            product.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
