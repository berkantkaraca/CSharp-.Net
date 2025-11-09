using _38_EntityFramework_CodeFirst_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _38_EntityFramework_CodeFirst_2.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Product
            builder
                .Property(p => p.Name)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder
                .Property(p => p.Price)
                .HasPrecision(18, 2)
                .IsRequired();

            //One-to-one
            builder
                .HasOne(p => p.ProductDetail)
                .WithOne(pd => pd.Product)
                .HasForeignKey<ProductDetail>(pd => pd.ProductId) //İki taraflı ilişki olduğu için foreign key ProductDetail tablosunda
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
