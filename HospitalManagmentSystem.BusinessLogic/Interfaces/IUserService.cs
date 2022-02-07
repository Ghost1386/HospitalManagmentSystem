using System.Collections.Generic;
using HospitalManagmentSystem.Common.Models;

namespace HospitalManagmentSystem.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();

        User Get(int id);

        void Delete(int id);

        void Create(User user);
    }
}
