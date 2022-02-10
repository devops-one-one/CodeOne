using System.Collections.Generic;
using GymOneBackend.Core.Model;
using GymOneBackend.Domain.IRepositories;

namespace GymOneBackend.Security.Repositories
{
    public class UserRepository: IUserRepository
    {
        public List<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Create(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}