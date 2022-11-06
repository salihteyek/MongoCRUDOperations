using MongoCRUDOperations.API.Models;
using MongoDB.Driver;

namespace MongoCRUDOperations.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserRepository(IMongoDatabase mongoDatabase)
        {
            _userCollection = mongoDatabase.GetCollection<User>("users");
        }

        public async Task<User> CreateAsync(User user)
        {
            await _userCollection.InsertOneAsync(user).ConfigureAwait(false);
            return user;
        }

        public Task DeleteAsync(string id)
        {
            return _userCollection.DeleteOneAsync(u => u.Id == id);
        }

        public Task<List<User>> GetAllAsync()
        {
            return _userCollection.Find(u => true).ToListAsync();
        }

        public Task<User> GetByIdAsync(string id)
        {
            return _userCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        public Task UpdateAsync(string id, User user)
        {
            return _userCollection.ReplaceOneAsync(x => x.Id == id, user);
        }
    }
}
