using BlogUserCreationService.Models;

namespace BlogUserCreationService.Commands
{
    public interface IUserRegCommands
    {
        int AddUserData(UserRegistration userRegistration);
    }
}
