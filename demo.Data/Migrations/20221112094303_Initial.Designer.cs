﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Data.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20221112094303_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LMS.Core.Domain.Books.Author", b =>
            {
                b.Property<int>("AuthorId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(450)");

                b.HasKey("AuthorId");

                b.HasIndex("Name")
                    .IsUnique()
                    .HasFilter("[Name] IS NOT NULL");

                b.ToTable("Authors", (string)null);
            });

            modelBuilder.Entity("LMS.Core.Domain.Books.Book", b =>
            {
                b.Property<int>("BookId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                b.Property<string>("CallNumber")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Description")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("ISBN")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                b.Property<string>("Language")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("MaxIssueDays")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasDefaultValue(10);

                b.Property<string>("Publisher")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Title")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("BookId");

                b.HasIndex("ISBN")
                    .IsUnique();

                b.ToTable("Books", (string)null);
            });

            modelBuilder.Entity("LMS.Core.Domain.Books.BookAuthor", b =>
            {
                b.Property<int>("BookId")
                    .HasColumnType("int");

                b.Property<int>("AuthorId")
                    .HasColumnType("int");

                b.HasKey("BookId", "AuthorId");

                b.HasIndex("AuthorId");

                b.ToTable("BookAuthor", (string)null);
            });

            modelBuilder.Entity("LMS.Core.Domain.Books.BookSubject", b =>
            {
                b.Property<int>("BookId")
                    .HasColumnType("int");

                b.Property<int>("SubjectId")
                    .HasColumnType("int");

                b.HasKey("BookId", "SubjectId");

                b.HasIndex("SubjectId");

                b.ToTable("BookSubject", (string)null);
            });

            modelBuilder.Entity("LMS.Core.Domain.Books.Subject", b =>
            {
                b.Property<int>("SubjectId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(450)");

                b.HasKey("SubjectId");

                b.HasIndex("Name")
                    .IsUnique()
                    .HasFilter("[Name] IS NOT NULL");

                b.ToTable("Subjects", (string)null);
            });

            modelBuilder.Entity("LMS.Core.Domain.Issues.Issue", b =>
            {
                b.Property<int>("IssueId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IssueId"));

                b.Property<int>("BookId")
                    .HasColumnType("int");

                b.Property<DateTime>("ExpireDate")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("IssueDate")
                    .HasColumnType("datetime2");

                b.Property<int>("MemberId")
                    .HasColumnType("int");

                b.HasKey("IssueId");

                b.HasIndex("BookId")
                    .IsUnique();

                b.HasIndex("MemberId");

                b.ToTable("Issues", (string)null);
            });

            modelBuilder.Entity("LMS.Core.Domain.Members.Member", b =>
            {
                b.Property<int>("MemberId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"));

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("MemberType")
                    .HasColumnType("int");

                b.Property<string>("PhoneNumber")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("MemberId");

                b.ToTable("Members", (string)null);
            });

            modelBuilder.Entity("LMS.Core.Domain.Books.BookAuthor", b =>
            {
                b.HasOne("LMS.Core.Domain.Books.Author", "Author")
                    .WithMany("BookAuthors")
                    .HasForeignKey("AuthorId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("LMS.Core.Domain.Books.Book", "Book")
                    .WithMany("BookAuthors")
                    .HasForeignKey("BookId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Author");

                b.Navigation("Book");
            });

            modelBuilder.Entity("LMS.Core.Domain.Books.BookSubject", b =>
            {
                b.HasOne("LMS.Core.Domain.Books.Book", "Book")
                    .WithMany("BookSubjects")
                    .HasForeignKey("BookId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("LMS.Core.Domain.Books.Subject", "Subject")
                    .WithMany("BookSubjects")
                    .HasForeignKey("SubjectId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Book");

                b.Navigation("Subject");
            });

            modelBuilder.Entity("LMS.Core.Domain.Issues.Issue", b =>
            {
                b.HasOne("LMS.Core.Domain.Books.Book", "Book")
                    .WithOne("Issue")
                    .HasForeignKey("LMS.Core.Domain.Issues.Issue", "BookId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("LMS.Core.Domain.Members.Member", "Member")
                    .WithMany("Issues")
                    .HasForeignKey("MemberId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Book");

                b.Navigation("Member");
            });

            modelBuilder.Entity("LMS.Core.Domain.Books.Author", b =>
            {
                b.Navigation("BookAuthors");
            });

            modelBuilder.Entity("LMS.Core.Domain.Books.Book", b =>
            {
                b.Navigation("BookAuthors");

                b.Navigation("BookSubjects");

                b.Navigation("Issue");
            });

            modelBuilder.Entity("LMS.Core.Domain.Books.Subject", b =>
            {
                b.Navigation("BookSubjects");
            });

            modelBuilder.Entity("LMS.Core.Domain.Members.Member", b =>
            {
                b.Navigation("Issues");
            });
#pragma warning restore 612, 618
        }
    }
}
