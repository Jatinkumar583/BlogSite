using BlogUserCreationService.Models;
using MongoDB.Driver;

namespace BlogUserCreationService.Repositories
{
    public class UserRegQueriesRepository : IUserRegQueriesRepository
    {
        private readonly IMongoCollection<UserRegistration> _userRegCollection;

        public UserRegQueriesRepository(IBlogStoreDBSetting settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _userRegCollection = database.GetCollection<UserRegistration>(settings.UserRegCollectionName);

        }      
        public UserRegistration GetUserInfo(User userDetails)
        {
            return _userRegCollection.Find(x => x.EmailId == userDetails.UserName).FirstOrDefault();
        }
    }
}
