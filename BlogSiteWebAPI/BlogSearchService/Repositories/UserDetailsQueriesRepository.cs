using BlogSearchService.Models;
using MongoDB.Driver;

namespace BlogSearchService.Repositories
{
    public class UserDetailsQueriesRepository : IUserDetailsQueriesRepository
    {
        private readonly IMongoCollection<UserRegistration> _userRegCollection;

        public UserDetailsQueriesRepository(IBlogStoreDBSetting settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _userRegCollection = database.GetCollection<UserRegistration>(settings.UserRegCollectionName);
        }
        public List<UserRegistration> GetAllUsers()
        {
            return _userRegCollection.Find(user => true).ToList();
        }
    }
}
