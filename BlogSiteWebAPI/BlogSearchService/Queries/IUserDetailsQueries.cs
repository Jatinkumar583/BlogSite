using BlogSearchService.Models;

namespace BlogSearchService.Queries
{
    public interface IUserDetailsQueries
    {
        List<UserRegistration> GetAllUsersData();
    }
}
