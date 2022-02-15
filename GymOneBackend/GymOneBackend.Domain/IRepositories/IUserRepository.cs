using System.Collections.Generic;
using GymOneBackend.Core.Model;

namespace GymOneBackend.Domain.IRepositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        bool Create(User user);
    }
}