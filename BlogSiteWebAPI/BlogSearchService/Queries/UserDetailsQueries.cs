using BlogSearchService.Models;
using BlogSearchService.Repositories;

namespace BlogSearchService.Queries
{
    public class UserDetailsQueries : IUserDetailsQueries
    {
        private readonly IUserDetailsQueriesRepository _queriesRepository;
        public UserDetailsQueries(IUserDetailsQueriesRepository queriesRepository)
        {
            _queriesRepository = queriesRepository;
        }
        public List<UserRegistration> GetAllUsersData()
        {
            return _queriesRepository.GetAllUsers();
        }
    }
}
