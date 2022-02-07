using System.Collections.Generic;
using HospitalManagmentSystem.BusinessLogic.Interfaces;
using HospitalManagmentSystem

namespace HospitalManagmentSystem.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }
        public User Get(int id)
        {
            return _userRepository.Get(id);
        }
        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public void Create(User user)
        {
            _userRepository.Create(user);
        }
    }
}
