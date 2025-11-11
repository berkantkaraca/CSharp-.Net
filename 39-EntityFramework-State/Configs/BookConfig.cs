using _39_EntityFramework_State.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _39_EntityFramework_State.Configs
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasData(
                    new Book { Id = 1, Title = "Hamlet", AuthorId = 1 },
                    new Book { Id = 2, Title = "Macbeth", AuthorId = 1 }
                );

            builder
                .Property(b => b.Title)
                .HasMaxLength(100)
                .IsRequired();

            //builder.HasOne(a => a.Author)
            //    .WithMany(a => a.Books)
            //    .HasForeignKey(x => x.AuthorId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
