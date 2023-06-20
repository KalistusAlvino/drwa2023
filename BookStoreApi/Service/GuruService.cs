using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class GuruService
{
    private readonly IMongoCollection<Guru> _gurusCollection;

    public GurusService(
        IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _gurusCollection = mongoDatabase.GetCollection<Guru>(
            bookStoreDatabaseSettings.Value.GuruCollectionName);
    }

    public async Task<List<Guru>> GetAsync() =>
        await _gurusCollection.Find(_ => true).ToListAsync();

    public async Task<Guru?> GetAsync(string nip) =>
        await _guruCollection.Find(x => x.Nip == nip).FirstOrDefaultAsync();

    public async Task CreateAsync(Guru newGuru) =>
        await _guruCollection.InsertOneAsync(newGuru);

    public async Task UpdateAsync(string nip, Guru updatedGuru) =>
        await _gurusCollection.ReplaceOneAsync(x => x.Nip == nip, updatedGuru);

    public async Task RemoveAsync(string nip) =>
        await _gurusCollection.DeleteOneAsync(x => x.Nip == nip);
}