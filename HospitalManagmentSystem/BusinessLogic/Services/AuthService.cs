using HospitalManagmentSystem.BusinessLogic.Interfaces;
using HospitalManagmentSystem.Common.Models;
using HospitalManagmentSystem.DAL.Interfaces;

namespace HospitalManagmentSystem.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public bool IsLogin(string login, string password, out int id)
        {
            id = -1;
            
            foreach (User user in _userRepository.GetUsers())
            {
                if (user.Login == login &&
                    user.Password == password)
                {
                    id = user.Id;
                    
                    return true;
                }
            }
            
            return false;
        }

        public bool IsRegistration(string login, string email)
        {
            foreach (User user in _userRepository.GetUsers())
            {
                if (user.Email == email || user.Login == login)
                {
                    return true;
                }
            }

            return false;
        }
    }
}