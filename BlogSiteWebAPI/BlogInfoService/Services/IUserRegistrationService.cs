using BlogInfoService.Models;

namespace BlogInfoService.Services
{
    public interface IUserRegistrationService
    {
        List<UserRegistration> GetAllUsers();
        UserRegistration GetUser(int userId);
        UserRegistration AddUser(UserRegistration userRegistration);
        void UpdateUserDetail(int userId,UserRegistration userRegistration);
        void DeleteUser(int userId);
    }
}
