using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class BooksService
{
    private readonly IMongoCollection<PresensiMengajar> _presensiMengajarCollection;

    public BooksService(
        IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _presensiMengajarCollection = mongoDatabase.GetCollection<PresensiMengajar>(
            bookStoreDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<PresensiMengajar>> GetAsync() =>
        await _presensiMengajarCollection.Find(_ => true).ToListAsync();

    public async Task<PresensiMengajar?> GetAsync(string nip) =>
        await _presensiMengajarCollection.Find(x => x.Nip == nip).FirstOrDefaultAsync();

    public async Task CreateAsync(PresensiMengajar newPresensiMengajar) =>
        await _presensiMengajarCollection.InsertOneAsync(newPresensiMengajar);

    public async Task UpdateAsync(string nip, PresensiMengajar updatedPresensiMengajar) =>
        await _presensiMengajarCollection.ReplaceOneAsync(x => x.Nip == nip, updatedPresensiMengajar);

    public async Task RemoveAsync(string nip) =>
        await _presensiMengajarCollection.DeleteOneAsync(x => x.Nip == nip);
}