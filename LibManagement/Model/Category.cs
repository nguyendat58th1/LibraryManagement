using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace LibManagement.Model
{
    public class Category
    {
        [Key]
        public int CategoryId {get; set;}
        [Required]
        public string CategoryName {get; set;}
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Book> Books {get; set;}

    }
}