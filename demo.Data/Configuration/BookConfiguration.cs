using demo.Core.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Data.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(b => b.BookId);
            builder.HasIndex(b => b.ISBN).IsUnique();
            builder.HasOne(i => i. Issue).WithOne(b => b.Book).HasForeignKey<Book>(b => b.BookId);
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.Publisher).IsRequired();
            builder.Property(b => b.ISBN).IsRequired();
            builder.Property(b => b.MaxIssueDays).HasDefaultValue(10);
        }
    }
}