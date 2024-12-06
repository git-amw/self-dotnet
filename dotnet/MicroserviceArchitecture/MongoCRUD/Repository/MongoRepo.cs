
using Microsoft.Extensions.Options;
using Models;
using MongoCRUD.Models;
using MongoDB.Driver;

namespace MongoCRUD.Repository
{
    public class MongoRepo
    {
        private IMongoCollection<Book> _booksCollection;

        public MongoRepo(IOptions<MongoDbSettings> mongoSetting)
        {
            var mongoClient = new MongoClient(mongoSetting.Value.ConnectionURI);

            var mongoDatabase = mongoClient.GetDatabase(mongoSetting.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<Book>(mongoSetting.Value.CollectionName);

        }

        public async Task<List<Book>> GetAsync() =>
        await _booksCollection.Find(_ => true).ToListAsync();

        public async Task<Book?> GetAsync(string id) =>
            await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Book newBook) =>
            await _booksCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Book updatedBook) =>
            await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _booksCollection.DeleteOneAsync(x => x.Id == id);
    }
}