using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibManagement.Enums;
using LibManagement.Model;
using LibManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookBorrowingRequestController : ControllerBase
    {
        private IBookBorrowingRequestService _brr;
        private IBBRDService _brrd;
        public BookBorrowingRequestController(IBookBorrowingRequestService brr, IBBRDService brrd)
        {
            _brr = brr;
            _brrd = brrd;

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
        public IActionResult Post(int userId, List<int> bookIds)
        {
            if (_brr.CreateRequest(userId,bookIds))
            {  
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, BookBorrowingRequest brr)
        {
            id = brr.RequestId;
            if (_brr.Update(brr))
            {
                return Ok();
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/approve")]
        public IActionResult ApproveBorrowRequest(int id,int userId)
        {
            var entity = _brr.GetById(id); 

            if (entity != null)
            {
                //entity.ApprovalUserId = Int32.Parse( HttpContext.Session.GetString("userId"));
                entity.Status = Status.Approve;
                entity.ApprovalUserId = userId;
                _brr.Update(entity);
                return Ok(entity);
            }
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/reject")]
        public IActionResult RejectBorrowRequest(int id, int userId)
        {
            var entity = _brr.GetById(id); 

            if (entity != null)
            {
                //entity.RejectUserId = Int32.Parse( HttpContext.Session.GetString("userId"));
                entity.Status = Status.Rejected;
                entity.RejectUserId = userId;
                _brr.Update(entity);
                return Ok(entity);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if (_brr.Delete(id))
            {
                return Ok();
            }
            return BadRequest();

        }
    }
}