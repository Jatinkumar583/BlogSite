using BlogUserCreationService.Models;

namespace BlogUserCreationService.Queries
{
    public interface IUserRegQueries
    {
        UserRegistration GetUserDataInfo(User userDetails);
    }
}
