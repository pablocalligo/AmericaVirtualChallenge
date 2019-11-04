using AmericaVirtualApi.Contracts;
using AmericaVirtualApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AmericaVirtualApi.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _user;

        public UserService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _user = database.GetCollection<User>(settings.UserCollectionName);
        }

        public List<User> GetAll()
        {
            return _user.Find(user => true).ToList();
        }

        public User Validate(string username, string password)
        {
            return _user.Find(user => user.Email == username && user.Password == password ).FirstOrDefault();
        }

        public User GetById(string id)
        {
            return _user.Find<User>(user => user.Id == id).FirstOrDefault();
        }

        public User Create(User user)
        {
            using (var algo = new SHA1Managed())
            {
                user.Password = GenerateHashString(algo, user.Password);
            }

            _user.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn)
        {
            _user.ReplaceOne(user => user.Id == id, userIn);
        }

        public void Remove(string id)
        {
            _user.DeleteOne(user => user.Id == id);
        }

        private static string GenerateHashString(HashAlgorithm algo, string text)
        {
            algo.ComputeHash(Encoding.UTF8.GetBytes(text));

            var result = algo.Hash;

            return string.Join(
                string.Empty,
                result.Select(x => x.ToString("x2")));
        }
    }
}
