﻿using demo.Core.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Data.Configuration
{
    public class BookSubjectConfiguration : IEntityTypeConfiguration<BookSubject>
    {
        public void Configure(EntityTypeBuilder<BookSubject> builder)
        {
            builder.ToTable("BookSubject");
            builder.HasKey(t => new { t.BookId, t.SubjectId });

            builder.HasOne(bs => bs.Book)
                .WithMany(s => s.BookSubjects)
                .HasForeignKey(bs => bs.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(bs => bs.Subject)
                .WithMany(s => s.BookSubjects)
                .HasForeignKey(bs => bs.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
 
