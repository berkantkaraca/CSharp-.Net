using _39_EntityFramework_State.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _39_EntityFramework_State.Configs
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                .HasData(
                    new Author { Id = 1, FirstName = "William", LastName = "Shakespeare" },
                    new Author { Id = 2, FirstName = "Fyodor", LastName = "Dostoevsky" }
                );

            builder
                .Property(a => a.FirstName)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder
                .Property(a => a.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
