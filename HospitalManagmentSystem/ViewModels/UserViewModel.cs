using System.ComponentModel.DataAnnotations;
using HospitalManagmentSystem.Common.Enums;

namespace HospitalManagmentSystem.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [MinLength(5)]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [StringLength(18)]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [StringLength(16)]       
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [StringLength(16)]        
        public string ConfirmPassword { get; set; }

        public Role Role { get; set; }
    }
}
