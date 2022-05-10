using System;
using HospitalManagmentSystem.Common.Enums;

namespace HospitalManagmentSystem.Common.Models
{
    public class Record
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int Department { get; set; }

        public int EmployeeId { get; set; }

        public string DateAndTime { get; set; }

        public int RecordStatus { get; set; }
    }
}
