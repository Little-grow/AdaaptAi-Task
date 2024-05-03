using System.Security.Claims;

namespace WebApplication1.DTO
{
    public class TokenRequestDto
    {
        public string Email { get; set; } 
        public string Password { get; set; }
    }
}