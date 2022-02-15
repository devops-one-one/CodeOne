﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using GymOneBackend.Core.Model;
using GymOneBackend.Domain.IRepositories;
using GymOneBackend.Security.Helpers;
using GymOneBackend.Security.IServices;
using GymOneBackend.Security.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GymOneBackend.Security.Services
{
    public class SecurityServices: ISecurityServices
    {
        private readonly IUserRepository _repo;
        private readonly IAuthenticationHelper _authenticationHelper;
        
        
        public SecurityServices(IConfiguration configuration, 
            IUserRepository repository,  IAuthenticationHelper authenticationHelper)
        {
            Configuration = configuration;
            _repo = repository;
            _authenticationHelper = authenticationHelper;
        }
        
        public IConfiguration Configuration { get; }
        
        public JwtToken GenerateJwtToken(string email, string password, out int userId)
        {
            userId = -1;
            var user = _repo.GetAll().FirstOrDefault(user => user.Email.Equals(email));
            if(user == null)
                return new JwtToken()
                {
                    Message = "Email or password not correct"
                };

            
            //Did we not find a user with the given username?
            if (_authenticationHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)
               )
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    Configuration["Jwt:Secret"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(Configuration["Jwt:Issuer"],
                    Configuration["Jwt:Audience"],
                    null,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );
                userId = user.Id;
                return new JwtToken(
                )
                {
                    Jwt = new JwtSecurityTokenHandler().WriteToken(token),
                    Message = "ok"
                };
            }
            //dont need else
            return new JwtToken()
            {
                Message = "Email or password not correct"
            };
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