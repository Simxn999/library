﻿// <auto-generated />
using System;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220715132441_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookLoan", b =>
                {
                    b.Property<int>("BooksBookID")
                        .HasColumnType("int");

                    b.Property<int>("LoansLoanID")
                        .HasColumnType("int");

                    b.HasKey("BooksBookID", "LoansLoanID");

                    b.HasIndex("LoansLoanID");

                    b.ToTable("BookLoan");

                    b.HasData(
                        new
                        {
                            BooksBookID = 2,
                            LoansLoanID = 1
                        },
                        new
                        {
                            BooksBookID = 1,
                            LoansLoanID = 2
                        },
                        new
                        {
                            BooksBookID = 1,
                            LoansLoanID = 3
                        });
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookID"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("BookID");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookID = 1,
                            Author = "Buddy The Cat",
                            Genre = "Adventure",
                            Quantity = 999,
                            Title = "Mice in Heaven"
                        },
                        new
                        {
                            BookID = 2,
                            Author = "TP-Link",
                            Genre = "Romantic",
                            Quantity = 3,
                            Title = "Archer AX50 User Guide"
                        });
                });

            modelBuilder.Entity("Library.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"), 1L, 1);

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerID = 1,
                            Email = "simon.johansson@mail.com",
                            Name = "Simon",
                            PhoneNumber = "123 456 78 91",
                            Surname = "Johansson"
                        },
                        new
                        {
                            CustomerID = 2,
                            Email = "elon.musk@mail.com",
                            Name = "Elon",
                            PhoneNumber = "123 456 78 92",
                            Surname = "Musk"
                        },
                        new
                        {
                            CustomerID = 3,
                            Email = "rebecca.gerdin@mail.com",
                            Name = "Rebecca",
                            PhoneNumber = "123 456 78 93",
                            Surname = "Gerdin"
                        });
                });

            modelBuilder.Entity("Library.Models.Loan", b =>
                {
                    b.Property<int>("LoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanID"), 1L, 1);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InitiatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.HasKey("LoanID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Loans");

                    b.HasData(
                        new
                        {
                            LoanID = 1,
                            CustomerID = 1,
                            DueDate = new DateTime(2022, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InitiatedDate = new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsReturned = true
                        },
                        new
                        {
                            LoanID = 2,
                            CustomerID = 2,
                            DueDate = new DateTime(2022, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InitiatedDate = new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsReturned = false
                        },
                        new
                        {
                            LoanID = 3,
                            CustomerID = 3,
                            DueDate = new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InitiatedDate = new DateTime(2022, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsReturned = false
                        });
                });

            modelBuilder.Entity("BookLoan", b =>
                {
                    b.HasOne("Library.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.Loan", null)
                        .WithMany()
                        .HasForeignKey("LoansLoanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Models.Loan", b =>
                {
                    b.HasOne("Library.Models.Customer", "Customer")
                        .WithMany("Loans")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Library.Models.Customer", b =>
                {
                    b.Navigation("Loans");
                });
#pragma warning restore 612, 618
        }
    }
}
