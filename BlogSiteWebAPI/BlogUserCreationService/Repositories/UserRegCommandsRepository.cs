using BlogUserCreationService.Models;
using MongoDB.Driver;

namespace BlogUserCreationService.Repositories
{
    public class UserRegCommandsRepository : IUserRegCommandsRepository
    {
        private readonly IMongoCollection<UserRegistration> _userRegCollection;

        public UserRegCommandsRepository(IBlogStoreDBSetting settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _userRegCollection = database.GetCollection<UserRegistration>(settings.UserRegCollectionName);

        }
        public int AddUser(UserRegistration userRegistration)
        {
            try
            {
                _userRegCollection.InsertOne(userRegistration);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
