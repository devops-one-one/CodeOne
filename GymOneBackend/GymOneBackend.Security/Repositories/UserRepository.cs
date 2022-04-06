using System.Collections.Generic;
using System.Linq;
using GymOneBackend.Core.Model;
using GymOneBackend.Domain.IRepositories;
using GymOneBackend.Repository;
using GymOneBackend.Repository.Entities;
using GymOneBackend.Security.Models;

namespace GymOneBackend.Security.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly SecurityContext _context;
        private readonly MainDBContext _ctx;
        
        public UserRepository(SecurityContext context, MainDBContext ctx)
        {
            _context = context;
            _ctx = ctx;
        }
        
        public List<User> GetAll()
        {
            // return _context.LoginUsers.ToList();
            return _context.LoginUsers.Select(u => new User
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName,
                PasswordHash = u.PasswordHash,
                PasswordSalt = u.PasswordSalt
            }).ToList();
        }

        public bool Create(User user)
        {
            var createdUser = _context.LoginUsers.Add(new LoginUser()
            {
                Email = user.Email,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
            });
            _context.SaveChanges();

            _ctx.Users.Add(new UserEntity
            {
                Email = user.Email,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
            });
            _ctx.SaveChanges();
            return createdUser != null;
        }
    }
}