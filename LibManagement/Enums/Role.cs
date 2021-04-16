using System.ComponentModel.DataAnnotations;

namespace LibManagement.Enums 
{
    public enum Role {
        [Display(Name = "Admin")]
        Admin,
        [Display(Name = "User")]
        User
    }
}