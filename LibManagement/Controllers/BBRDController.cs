using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibManagement.Model;
using LibManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BBRDController : ControllerBase
    {
        private IBBRDService _brrd;
        public BBRDController (IBBRDService brrd)
        {
            _brrd = brrd;
        }
        [HttpGet]
        public ActionResult<IEnumerable<BookBorrowingRequestDetail>> Get()
        {
           return  _brrd.GetAll();
        }


        [HttpPost]
        public void Post(BookBorrowingRequestDetail brrd)
        {
            _brrd.Create(brrd);
        }

        [HttpPut("{id}")]
        public void Put(int id, BookBorrowingRequestDetail brrd)
        {
            _brrd.Update(brrd);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _brrd.Delete(id);
        }
    }
}