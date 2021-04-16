using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibManagement.Model
{
    public class LibraryDBContext : DbContext
    {
        public LibraryDBContext(DbContextOptions<LibraryDBContext> options) : base(options) { }
        public LibraryDBContext() { }



        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<Author> Authors { get; set; }
        public DbSet<BookBorrowingRequest> BookBorrowingRequests { get; set; }
        public DbSet<BookBorrowingRequestDetail> BookBorrowRequestDetails { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer("Server = LAPTOP-O71PKJ1L\\SQLEXPRESS;Database = Library;Trusted_Connection=True;MultipleActiveResultSets= true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
            .Property(f => f.BookId)
            .ValueGeneratedOnAdd();
            builder.Entity<Category>()
            .Property(f => f.CategoryId)
            .ValueGeneratedOnAdd();
            builder.Entity<User>()
            .Property(f => f.UserId)
            .ValueGeneratedOnAdd();
           
            builder.Entity<BookBorrowingRequest>()
           .Property(f => f.RequestId)
           .ValueGeneratedOnAdd();
            builder.Entity<BookBorrowingRequestDetail>()
          .Property(f => f.Id)
          .ValueGeneratedOnAdd();
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(new Category
            {   CategoryId = 2,
                CategoryName = "Math"

            });
            builder.Entity<Category>().HasData(new Category
            {
                CategoryId = 1,
                CategoryName = "Sciene"

            });
              builder.Entity<Book>().HasData(new Book
            {
                BookId = 1,
                Title = "ABC",
                Description = "Abc",
                CategoryId = 1

            });
          
        }

    }
}