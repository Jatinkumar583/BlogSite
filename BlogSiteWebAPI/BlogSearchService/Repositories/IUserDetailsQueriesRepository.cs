using BlogSearchService.Models;

namespace BlogSearchService.Repositories
{
    public interface IUserDetailsQueriesRepository
    {
        List<UserRegistration> GetAllUsers();
    }
}
