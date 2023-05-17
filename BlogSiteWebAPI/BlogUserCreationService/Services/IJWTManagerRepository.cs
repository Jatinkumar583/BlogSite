using BlogUserCreationService.Models;

namespace BlogUserCreationService.Services
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(User users);
    }
}
