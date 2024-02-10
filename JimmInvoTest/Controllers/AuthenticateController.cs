using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using JimmInvoTest.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace JimmInvoTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly TaskDbContext _context;
        private readonly ILogger<AuthenticateController> _logger;
        private readonly IConfiguration _configuration;

        public AuthenticateController(TaskDbContext context, ILogger<AuthenticateController> 
            logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }


        
        [AllowAnonymous]
        [HttpPost, Route("Login")]
        public IActionResult Login([FromBody] TokenRequest request)
        {
            if (Authenticate(request.Username, request.Password))
            {
                var token = GenerateJwtToken(request.Username);
                return Ok(new { Token = token });
            }
            else
            {
                return Unauthorized("Invalid username or password");
            }
        }


        private bool Authenticate(string username, string password)
        {
            var user = _context.UserLogin.FirstOrDefault(u => u.Username == username);
            if (user == null)
                return false;

            // Hash the provided password and compare it with the stored hash
            var hashedPassword = HashPassword(password);
            return user.PasswordHash == hashedPassword;
        }


        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private string GenerateJwtToken(string username)
        {
            var keyValue = _configuration["JWT:Secret"];
            var issuerValue = _configuration["JWT:issuer"];
            var audienceValue = _configuration["JWT:audience"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyValue));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
                // Add more claims as needed for authorization purposes
            };

            var token = new JwtSecurityToken(
                issuer: issuerValue,
                audience: audienceValue,
                claims: claims,
                expires: DateTime.Now.AddHours(1), // Token expiration time
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
