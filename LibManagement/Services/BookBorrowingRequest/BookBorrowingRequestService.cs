using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace LibManagement.Services
{
    public class BookBorrowingRequestService : IBookBorrowingRequestService
    {
        private LibraryDBContext _context;
        public BookBorrowingRequestService(LibraryDBContext context)
        {
            _context = context;
        }
        public bool Create(BookBorrowingRequest bbr)
        {
            try
            {
                if (_context.BookBorrowRequestDetails.Count() > 5)
                {
                    return false;
                }
                else
                {
                    _context.BookBorrowingRequests.Add(bbr);
                    _context.SaveChanges();
                    return true;
                }


            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var bbr = _context.BookBorrowingRequests.FirstOrDefault(x => x.RequestId == id);
            try
            {
                _context.BookBorrowingRequests.Remove(bbr);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public List<BookBorrowingRequest> GetAll()
        {
            return _context.BookBorrowingRequests.Include(x => x.BookBorrowRequestDetails).ToList();
        }

        public bool Update(BookBorrowingRequest bbr)
        {
            try
            {
                var item = _context.BookBorrowingRequests.FirstOrDefault(x => x.RequestId == bbr.RequestId);
                item.RequestId = bbr.RequestId;
                item.DateRequest = bbr.DateRequest;
                item.Status = bbr.Status;
                item.RequestUserId = bbr.RequestUserId;
                item.ReturnRequest = bbr.ReturnRequest;
                item.RejectUserId = bbr.RejectUserId;
                item.ApprovalUserId = bbr.ApprovalUserId;
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