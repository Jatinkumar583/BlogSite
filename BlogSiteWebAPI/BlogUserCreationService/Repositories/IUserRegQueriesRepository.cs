using BlogUserCreationService.Models;

namespace BlogUserCreationService.Repositories
{
    public interface IUserRegQueriesRepository
    {
        UserRegistration GetUserInfo(User userDetails);
    }
}
