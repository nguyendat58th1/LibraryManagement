using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibManagement.Model;
using LibManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookBorrowingRequestController : ControllerBase
    {
        private IBookBorrowingRequestService _brr;
        public BookBorrowingRequestController(IBookBorrowingRequestService brr)
        {
            _brr = brr;
        }
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public ActionResult<IEnumerable<BookBorrowingRequest>> Get()
        {
            return _brr.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult<BookBorrowingRequest> Get(int id)
        {
            return _brr.GetById(id);
        }


        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public void Post(BookBorrowingRequest brr)
        {
            _brr.Create(brr);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void Put(int id, BookBorrowingRequest brr)
        {
            _brr.Update(brr);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            _brr.Delete(id);
        }
    }
}