using System.Collections.Generic;
using HospitalManagmentSystem.Common.Models;

namespace HospitalManagmentSystem.DAL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();

        User Get(int id);

        void Delete(int id);

        void Create(User user);
    }
}
