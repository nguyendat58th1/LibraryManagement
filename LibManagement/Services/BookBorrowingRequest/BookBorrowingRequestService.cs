using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibManagement.Enums;
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

        public bool Create(BookBorrowingRequest entity)
        {
            throw new NotImplementedException();
        }

        public bool CreateRequest(int userId , List<int> bookIds)
        {
            try
            {
                var checkMonth = _context.BookBorrowingRequests.Count(x => x.RequestUserId == userId
                                                                         && x.DateRequest.Month == DateTime.Now.Month
                                                                         && x.DateRequest.Year == DateTime.Now.Year);

                if (bookIds.Count() > 5 || checkMonth > 3)
                {
                    return false;
                }
                else
                {
                    var request = new BookBorrowingRequest {
                        RequestUserId = userId,
                        DateRequest = DateTime.Now,
                        Status = Status.Waiting

                    };
                    _context.BookBorrowingRequests.Add(request);
                    _context.SaveChanges();
                    
                    foreach(var item in bookIds)
                    {
                        var requestdetail = new BookBorrowingRequestDetail {
                            RequestId = request.RequestId,
                            BookId = item
                        };
                        _context.BookBorrowRequestDetails.Add(requestdetail);
                    }
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

        public BookBorrowingRequest GetById(int id)
        {
            return _context.BookBorrowingRequests.Find(id);
        }
        public bool Update(BookBorrowingRequest bbr)
        {
            try
            {
                var item = _context.BookBorrowingRequests.FirstOrDefault(x => x.RequestId == bbr.RequestId);
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