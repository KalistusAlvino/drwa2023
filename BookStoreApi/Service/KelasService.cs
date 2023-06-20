using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class KelasService
{
    private readonly IMongoCollection<Kelas> _kelasCollection;

    public BooksService(
        IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _kelasCollection = mongoDatabase.GetCollection<Kelas>(
            bookStoreDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<Kelas>> GetAsync() =>
        await _kelasCollection.Find(_ => true).ToListAsync();

    public async Task<Book?> GetAsync(string id) =>
        await _kelasCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Kelas newKelas) =>
        await _kelasCollection.InsertOneAsync(newKelas);

    public async Task UpdateAsync(string id, Kelas updatedKelas) =>
        await _kelasCollection.ReplaceOneAsync(x => x.Id == id, updatedKelas);

    public async Task RemoveAsync(string id) =>
        await _kelasCollection.DeleteOneAsync(x => x.Id == id);
}