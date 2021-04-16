using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using LibManagement.Enums;

namespace LibManagement.Model
{
    public class User
    {
        [Key]
        public int UserId {get; set;}
        [Required]
        public string Username {get; set;}
        [Required]
        public string Password {get; set;}
        public string Name {get; set;}
        public DateTime DoB {get; set;}
        [Required]
        public Role Role {get; set;}
      
        public virtual ICollection<BookBorrowingRequest> BookBorrowingRequests {get; set;}
    }
}