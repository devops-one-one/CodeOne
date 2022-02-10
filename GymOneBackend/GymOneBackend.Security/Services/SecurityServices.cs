using GymOneBackend.Security.IServices;
using GymOneBackend.Security.Models;

namespace GymOneBackend.Security.Services
{
    public class SecurityServices: ISecurityServices
    {
        public JwtToken GenerateJwtToken(string email, string password, out int userId)
        {
            throw new System.NotImplementedException();
        }

        public bool Create(string loginDtoEmail, string loginDtoPassword)
        {
            throw new System.NotImplementedException();
        }

        public bool EmailExists(string loginDtoEmail)
        {
            throw new System.NotImplementedException();
        }
    }
}