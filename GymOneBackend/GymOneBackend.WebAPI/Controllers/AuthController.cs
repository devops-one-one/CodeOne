using GymOneBackend.Security.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymOneBackend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            string userName;
            var token = _securityService.GenerateJwtToken(loginDto.Email, loginDto.Password, out userId, out userName);
            return new TokenDto
            {
                Jwt = token.Jwt,
                Message = token.Message,
                UserId = userId,
                UserName = userName,
            };
            
        }
        
        
        [AllowAnonymous]
        [HttpPost(nameof(Register))]
        public ActionResult<TokenDto> Register([FromBody] RegisterDto registerDto)
        {
            var exists = _securityService.EmailExists(registerDto.Email);
            if(exists)
                return BadRequest("Email already exists");
            if (_securityService.Create(registerDto.Email, registerDto.Password, registerDto.userName))
            {
                int userId;
                string userName;
                var token = _securityService.GenerateJwtToken(registerDto.Email, registerDto.Password, out userId, out userName);
                return new TokenDto
                {
                    Jwt = token.Jwt,
                    Message = token.Message,
                    UserId = userId,
                    UserName = userName,
                };
            }
            return BadRequest("couldn't log in");
        }
    }

    public class TokenDto
    {
        public string Jwt { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    
    public class RegisterDto
    {
        public string Email { get; set; }
        public string userName { get; set; }
        public string Password { get; set; }
    }
}