using BlogSearchService.Models;

namespace BlogSearchService.Services
{
    public interface IUserRegistrationService
    {
        List<UserRegistration> GetAllUsers();
        UserRegistration GetUser(int userId);
        int AddUser(UserRegistration userRegistration);
        void UpdateUserDetail(int userId, UserRegistration userRegistration);
        int DeleteUser(int userId);
    }
}
