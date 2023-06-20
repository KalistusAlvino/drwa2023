using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class PresensiHarianGuruService
{
    private readonly IMongoCollection<PresesiHarianGuru> _presensiHarianGuruCollection;

    public PresensiHarianGuruService(
        IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _presensiHarianGuruCollection = mongoDatabase.GetCollection<PresesiHarianGuru>(
            bookStoreDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<PresesiHarianGuru>> GetAsync() =>
        await _presensiHarianGuruCollection.Find(_ => true).ToListAsync();

    public async Task<PresesiHarianGuru?> GetAsync(string nip) =>
        await _presensiHarianGuruCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(PresesiHarianGuru newPresensiHarianGuru) =>
        await _presensiHarianGuruCollection.InsertOneAsync(newPresensiHarianGuru);

    public async Task UpdateAsync(string nip, PresesiHarianGuru updatedPresensiHarianGuru) =>
        await _presensiHarianGuruCollection.ReplaceOneAsync(x => x.Nip == nip, updatedPresensiHarianGuru);

    public async Task RemoveAsync(string nip) =>
        await _presensiHarianGuruCollection.DeleteOneAsync(x => x.Nip == nip);
}