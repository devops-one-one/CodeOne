using GymOneBackend.Security.Models;

namespace GymOneBackend.Security.IServices
{
    public interface ISecurityServices
    {
        JwtToken GenerateJwtToken(string email, string password, out int userId, out string userName);
        bool Create(string loginDtoEmail, string loginDtoPassword, string userNameDto);
        bool EmailExists(string loginDtoEmail);
    }
}