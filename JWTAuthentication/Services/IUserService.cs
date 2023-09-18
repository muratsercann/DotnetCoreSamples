using JWTAuthentication.DTOs;

namespace JWTAuthentication.Services
{
    public interface IUserService
    {
        List<Models.User> GetAllUsers();

        Task<UserResource> Register(RegisterResource resource, CancellationToken cancellationToken);
        Task<UserResource> Login(LoginResource resource, CancellationToken cancellationToken , IConfiguration config);
    }
}
