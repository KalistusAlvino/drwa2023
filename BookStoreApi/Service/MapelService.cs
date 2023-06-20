using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class BooksService
{
    private readonly IMongoCollection<Mapel> _mapelsCollection;

    public BooksService(
        IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _booksCollection = mongoDatabase.GetCollection<Book>(
            bookStoreDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<Mapel>> GetAsync() =>
        await _mapelsCollection.Find(_ => true).ToListAsync();

    public async Task<Mapel?> GetAsync(string id) =>
        await _mapelsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Mapel newMapel) =>
        await _mapelsCollection.InsertOneAsync(newMapel);

    public async Task UpdateAsync(string id, Mapel updatedMapel) =>
        await _mapelsCollection.ReplaceOneAsync(x => x.Id == id, updatedMapel);

    public async Task RemoveAsync(string id) =>
        await _mapelsCollection.DeleteOneAsync(x => x.Id == id);
}