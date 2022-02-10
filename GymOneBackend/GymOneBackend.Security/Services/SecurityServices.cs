using System.Linq;
using GymOneBackend.Core.Model;
using GymOneBackend.Domain.IRepositories;
using GymOneBackend.Security.Helpers;
using GymOneBackend.Security.IServices;
using GymOneBackend.Security.Models;

namespace GymOneBackend.Security.Services
{
    public class SecurityServices: ISecurityServices
    {
        private readonly IUserRepository _repo;
        private readonly IAuthenticationHelper _authenticationHelper;
        
        public JwtToken GenerateJwtToken(string email, string password, out int userId)
        {
            throw new System.NotImplementedException();
        }

        public bool Create(string loginDtoEmail, string loginDtoPassword)
        {
            _authenticationHelper.CreatePasswordHash(loginDtoPassword,
                out var hash, out var salt);
            return _repo.Create(new User
            {
                Email = loginDtoEmail,
                PasswordHash = hash,
                PasswordSalt = salt
            });
        }

        public bool EmailExists(string email)
        {
            var user = _repo.GetAll().FirstOrDefault(user => user.Email.Equals(email));
            return user != null;
        }
    }
}