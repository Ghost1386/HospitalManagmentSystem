using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using HospitalManagmentSystem.Common.Enums;

namespace HospitalManagmentSystem.ViewModels
{
    public class RecordViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public Department Department { get; set; }
        
        public int EmployeeId { get; set; }
        
        public string DateAndTime { get; set; }
        
        public RecordStatus RecordStatus { get; set; }
    }
}
