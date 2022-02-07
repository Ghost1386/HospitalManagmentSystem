using System.ComponentModel.DataAnnotations;
using HospitalManagmentSystem.Common.Enums;

namespace HospitalManagmentSystem.ViewModels
{
    public class RecordViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(0)]
        [StringLength(10)]
        public int UserId { get; set; }

        [Required]
        [MinLength(5)]
        [StringLength(20)]
        public string Department { get; set; }

        [Required]
        [MinLength(0)]
        [StringLength(10)]
        public int EmployeeId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [MinLength(0)]
        [StringLength(10)]
        public string DateAndTime { get; set; }

        [Required]
        public RecordStatus RecordStatus { get; set; }
    }
}
