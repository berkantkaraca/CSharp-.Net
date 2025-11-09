using _38_EntityFramework_CodeFirst_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _38_EntityFramework_CodeFirst_2.Configs
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //Customer
            builder
                .Property(c => c.Email)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder
                .HasIndex(c => c.Email)
                .IsUnique();

            builder
                .Property(c => c.FirstName)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder
                .Property(c => c.LastName)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder
                .Ignore(c => c.FullName);

            builder
                .Property(c => c.Phone)
                .HasColumnType("char(10)")
                .IsRequired(false);

            builder
                .Property(c => c.BirthDate)
                .IsRequired(false)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
