using _38_EntityFramework_CodeFirst_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _38_EntityFramework_CodeFirst_2.Configs
{
    public class ProductDetailConfig : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {

            //One-to-one
            builder
                .HasKey(pd => pd.ProductId);

            builder
                .Property(pd => pd.Description)
                .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder
                .Property(pd => pd.Color)
                .IsRequired(false);
        }
    }
}
