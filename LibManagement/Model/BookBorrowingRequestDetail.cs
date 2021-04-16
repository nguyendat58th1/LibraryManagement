using System.ComponentModel.DataAnnotations;

namespace LibManagement.Model
{
    public class BookBorrowingRequestDetail
    {
        [Key]
        public int Id {get; set;}
        [Required]
      
        public int BookId {get; set;}

        public virtual Book Book {get; set;}
        [Required]
        public int RequestId {get; set;}
        public virtual BookBorrowingRequest Request {get; set;}
        
    }
}