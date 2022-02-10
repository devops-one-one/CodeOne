namespace GymOneBackend.Security.Helpers
{
    public class AuthenticationHelper: IAuthenticationHelper
    {
        public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            throw new System.NotImplementedException();
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            throw new System.NotImplementedException();
        }
    }
}