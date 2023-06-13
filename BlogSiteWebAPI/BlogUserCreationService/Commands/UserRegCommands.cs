using BlogUserCreationService.Models;
using BlogUserCreationService.Repositories;

namespace BlogUserCreationService.Commands
{
    public class UserRegCommands : IUserRegCommands
    {
        private readonly IUserRegCommandsRepository _commandRepository;
        public UserRegCommands(IUserRegCommandsRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }
        public int AddUserData(UserRegistration userRegistration)
        {
            return _commandRepository.AddUser(userRegistration);
        }
    }
}
