using _38_EntityFramework_CodeFirst_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _38_EntityFramework_CodeFirst_2.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Category
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            //One-to-many
            builder
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
