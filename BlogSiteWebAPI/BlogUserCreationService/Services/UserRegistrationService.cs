using BlogUserCreationService.Models;
using MongoDB.Driver;

namespace BlogUserCreationService.Services
{
    public class UserRegistrationService:IUserRegistrationService
    {
        private readonly IMongoCollection<UserRegistration> _userRegCollection;

        public UserRegistrationService(IBlogStoreDBSetting settings, IMongoClient mongoClient)
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
            catch (Exception)
            {
                return 0;
            }            
        }

        public int DeleteUser(int userId)
        {
            try
            {
                var itemToRemove = _userRegCollection.Find(user => user.UserId == userId).SingleOrDefault();
                if (itemToRemove != null)
                {
                    _userRegCollection.DeleteOne(user => user.UserId == userId);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }            
        }

        public List<UserRegistration> GetAllUsers()
        {
            return _userRegCollection.Find(user => true).ToList();
        }

        public UserRegistration GetUser(int userId)
        {
            return _userRegCollection.Find(user => user.UserId == userId).FirstOrDefault();
        }

        public void UpdateUserDetail(int userId, UserRegistration userRegistration)
        {
            _userRegCollection.ReplaceOne(user => user.UserId == userId, userRegistration);
        }
    }
}
