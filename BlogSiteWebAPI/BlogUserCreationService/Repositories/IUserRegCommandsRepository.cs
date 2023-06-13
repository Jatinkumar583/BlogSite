using BlogUserCreationService.Models;

namespace BlogUserCreationService.Repositories
{
    public interface IUserRegCommandsRepository
    {
        //List<UserRegistration> GetAllUsers();
        //UserRegistration GetUser(int userId);
        //UserRegistration GetUserInfo(User userDetails);
        int AddUser(UserRegistration userRegistration);
        //void UpdateUserDetail(int userId, UserRegistration userRegistration);
        //int DeleteUser(int userId);
    }
}
