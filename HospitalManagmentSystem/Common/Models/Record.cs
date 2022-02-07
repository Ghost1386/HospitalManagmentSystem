using System;

namespace HospitalManagmentSystem.Common.Models
{
    public class Record
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Department { get; set; }

        public int EmployeeId { get; set; }

        public DateTime DateAndTime { get; set; }

        public int RecordStatus { get; set; }
    }
}
