using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace JWTAuthentication.DTOs
{
    public class RegisterResource
    {
        public string Username { get; set; }    

        public string Email { get; set; }

        public string Password { get; set; }    
    }
}
