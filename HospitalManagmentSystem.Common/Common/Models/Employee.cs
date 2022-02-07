namespace HospitalManagmentSystem.Common.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public int DepartmentId { get; set; }

        public int EmployeeRole { get; set; }
    }
}
