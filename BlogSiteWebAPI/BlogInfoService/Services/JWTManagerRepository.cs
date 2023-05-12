using BlogInfoService.Models;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogInfoService.Services
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private readonly IMongoCollection<UserRegistration> _userRegCollection;
        private readonly IConfiguration configuartion;

        public JWTManagerRepository(IConfiguration iconfiguration, IBlogStoreDBSetting settings, IMongoClient mongoClient)
        {
            configuartion = iconfiguration;
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _userRegCollection = database.GetCollection<UserRegistration>(settings.UserRegCollectionName);
        }
        public Tokens Authenticate(User users)
        {
            var userList = _userRegCollection.Find(user => true).ToList();
            if (!userList.Any(x => x.EmailId == users.UserName && x.Password == users.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuartion["JWT:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,users.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }

    }
}
