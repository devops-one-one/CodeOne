using GymOneBackend.Security.Models;

namespace GymOneBackend.Security.IServices
{
    public interface ISecurityServices
    {
        JwtToken GenerateJwtToken(string email, string password, out int userId);
        bool Create(string loginDtoEmail, string loginDtoPassword);
        bool EmailExists(string loginDtoEmail);
    }
}