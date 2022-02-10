﻿using GymOneBackend.Security.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymOneBackend.WebAPI.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly ISecurityServices _securityService;
        
        public AuthController(ISecurityServices securityService)
        {
            _securityService = securityService;
        }
        
        
        // POST: api/Login
        [AllowAnonymous] //people cant log in not being logged in
        [HttpPost(nameof(Login))]
        public ActionResult<TokenDto> Login([FromBody] LoginDto loginDto)
        {
            int userId; 
            var token = _securityService.GenerateJwtToken(loginDto.Email, loginDto.Password, out userId);
            return new TokenDto
            {
                Jwt = token.Jwt,
                Message = token.Message,
                UserId = userId,
            };
            
        }
    }

    public class TokenDto
    {
        public string Jwt { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; } 
    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}