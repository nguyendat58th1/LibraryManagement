using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibManagement.Model
{
    public class Category
    {
        [Key]
        public int CategoryId {get; set;}
        [Required]
        public string CategoryName {get; set;}
        public virtual ICollection<Book> Books {get; set;}

    }
}