using HospitalManagmentSystem.Common.Enums;

namespace HospitalManagmentSystem.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string SurName { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public Department Department { get; set; }
    }
}
