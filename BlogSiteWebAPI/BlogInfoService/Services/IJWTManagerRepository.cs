using BlogInfoService.Models;

namespace BlogInfoService.Services
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(User users);
    }
}
