using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace LibManagement.Services
{
    public class BookService : IBookService
    {
        private LibraryDBContext _context;
        public BookService(LibraryDBContext context)
        {
            _context = context;
        }
        public bool Create(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.BookId == id);
            try
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }

        }

        public List<Book> GetAll()
        {
            return _context.Books.Include(x => x.BookBorrowingRequestDetails).ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public bool Update(Book book)
        {
            try
            {
                var item = _context.Books.FirstOrDefault(x => x.BookId == book.BookId);
                item.BookId = book.BookId;
                item.Title = book.Title;
                item.Image = book.Image;
                item.Description = book.Description;
                item.CategoryId = book.CategoryId;
                _context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }

        }
    }
}