using BlogUserCreationService.Models;
using BlogUserCreationService.Repositories;

namespace BlogUserCreationService.Queries
{
    public class UserRegQueries : IUserRegQueries
    {
        private readonly IUserRegQueriesRepository _commandRepository;
        public UserRegQueries(IUserRegQueriesRepository userRegQueriesRepository)
        {
            _commandRepository=userRegQueriesRepository;
        }
        public UserRegistration GetUserDataInfo(User userDetails)
        {
           return _commandRepository.GetUserInfo(userDetails);
        }
    }
}
