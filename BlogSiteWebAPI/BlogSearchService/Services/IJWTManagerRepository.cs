using BlogSearchService.Models;

namespace BlogSearchService.Services
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(User users);

    }
}
