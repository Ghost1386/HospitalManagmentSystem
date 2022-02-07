using System.ComponentModel.DataAnnotations;

namespace HospitalManagmentSystem.ViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        [MinLength(6)]
        [StringLength(18)]        
        public string Login { get; set; }

        [Required]
        [MinLength(6)]
        [StringLength(16)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
