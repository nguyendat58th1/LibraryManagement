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
    public class BookController : ControllerBase
    {
        private IBookService _bookservice;
        public BookController(IBookService bookService)
        {
            _bookservice = bookService;
        }
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return _bookservice.GetAll();
        }
        [HttpGet("Admin")]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<Book>> GetForAdmin()
        {
            return _bookservice.GetAll();
        }
        
        [HttpGet("{id}")]

        [Authorize(Roles = "Admin,User")]
        public ActionResult<Book> Get(int id)
        {
            return _bookservice.GetById(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post(Book book)
        {
            if (_bookservice.Create(book))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, Book book)
        {
            id = book.BookId;
            if (_bookservice.Update(book))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if (_bookservice.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }
        // [HttpPost("addrequestdetail")]
        // public IActionResult PostRequest(int id)
        // {


        // }
    }
}