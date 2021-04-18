﻿// <auto-generated />
using System;
using LibManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibManagement.Migrations
{
    [DbContext(typeof(LibraryDBContext))]
    partial class LibraryDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibManagement.Model.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            CategoryId = 1,
                            Description = "Abc",
                            Title = "ABC"
                        });
                });

            modelBuilder.Entity("LibManagement.Model.BookBorrowingRequest", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApprovalUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRequest")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RejectUserId")
                        .HasColumnType("int");

                    b.Property<int>("RequestUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnRequest")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("RequestId");

                    b.HasIndex("RequestUserId");

                    b.ToTable("BookBorrowingRequests");
                });

            modelBuilder.Entity("LibManagement.Model.BookBorrowingRequestDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("RequestId");

                    b.ToTable("BookBorrowRequestDetails");
                });

            modelBuilder.Entity("LibManagement.Model.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Math"
                        },
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Sciene"
                        });
                });

            modelBuilder.Entity("LibManagement.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LibManagement.Model.Book", b =>
                {
                    b.HasOne("LibManagement.Model.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LibManagement.Model.BookBorrowingRequest", b =>
                {
                    b.HasOne("LibManagement.Model.User", "RequestUser")
                        .WithMany("BookBorrowingRequests")
                        .HasForeignKey("RequestUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestUser");
                });

            modelBuilder.Entity("LibManagement.Model.BookBorrowingRequestDetail", b =>
                {
                    b.HasOne("LibManagement.Model.Book", "Book")
                        .WithMany("BookBorrowingRequestDetails")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibManagement.Model.BookBorrowingRequest", "Request")
                        .WithMany("BookBorrowRequestDetails")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("LibManagement.Model.Book", b =>
                {
                    b.Navigation("BookBorrowingRequestDetails");
                });

            modelBuilder.Entity("LibManagement.Model.BookBorrowingRequest", b =>
                {
                    b.Navigation("BookBorrowRequestDetails");
                });

            modelBuilder.Entity("LibManagement.Model.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibManagement.Model.User", b =>
                {
                    b.Navigation("BookBorrowingRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
