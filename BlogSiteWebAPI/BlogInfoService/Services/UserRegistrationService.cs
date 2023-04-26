using BlogInfoService.Models;
using MongoDB.Driver;
namespace BlogInfoService.Services
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IMongoCollection<UserRegistration> _userRegCollection;

        public UserRegistrationService(IBlogStoreDBSetting settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _userRegCollection= database.GetCollection<UserRegistration>(settings.UserRegCollectionName);

        }
        public UserRegistration AddUser(UserRegistration userRegistration)
        {
            _userRegCollection.InsertOne(userRegistration);
            return userRegistration;
        }

        public void DeleteUser(int userId)
        {
            _userRegCollection.DeleteOne(user => user.UserId == userId);
        }

        public List<UserRegistration> GetAllUsers()
        {
            return _userRegCollection.Find(user=>true).ToList();
        }

        public UserRegistration GetUser(int userId)
        {
            return _userRegCollection.Find(user => user.UserId==userId).FirstOrDefault();
        }

        public void UpdateUserDetail(int userId, UserRegistration userRegistration)
        {
            _userRegCollection.ReplaceOne(user => user.UserId == userId, userRegistration);
        }
    }
}
