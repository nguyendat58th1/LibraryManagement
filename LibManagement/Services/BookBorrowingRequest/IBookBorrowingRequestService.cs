using System.Collections.Generic;
using LibManagement.Model;
namespace LibManagement.Services
{
    public interface IBookBorrowingRequestService : IHandler<BookBorrowingRequest>
    {
        bool CreateRequest(int userId , List<int> bookIds);
     
    }
}