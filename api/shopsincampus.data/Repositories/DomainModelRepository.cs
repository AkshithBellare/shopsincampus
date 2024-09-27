using System;
using shopsincampus.data.Interfaces;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using ZstdSharp.Unsafe;
using MongoDB.Bson;
namespace shopsincampus.data.Repositories;

public class DomainModelRepository<T> : IDomainModelRepository<T> where T : class
{
    private readonly IMongoDatabase _database;
    private readonly Dictionary<string, IMongoCollection<T>> _collectionCache;

    public DomainModelRepository(IMongoDatabase database)
    {
        _database = database;
        _collectionCache = new Dictionary<string, IMongoCollection<T>>();
    }

    public IMongoCollection<T> GetCollection(string collectionName)
    {
        if (!_collectionCache.TryGetValue(collectionName, out var collection))
        {
            collection = _database.GetCollection<T>(collectionName);
            _collectionCache[collectionName] = collection; // Cache the collection
        }
        return collection;
    }

    // public async Task<JObject> FindByIdAsync(string id, string collectionName)
    // {
    //     var filter = Builders<JObject>.Filter.Eq("_id", id);
    //     var collection = GetCollection(collectionName);
    //     return await collection.Find(filter).FirstOrDefaultAsync();
    // }

    // public async Task<JObject> FindOneAsync(FilterDefinition<BsonDocument> filter, string collectionName)
    // {
    //     var collection = GetCollection(collectionName);
    //     return await collection.Find(filter).FirstOrDefaultAsync();
    // }

    public async Task<List<T>> FindAllAsync(FilterDefinition<T> filter, string collectionName)
    {
        var collection = _database.GetCollection<T>(collectionName);
        var cursor = await collection.FindAsync(filter ?? Builders<T>.Filter.Empty);
        var documents = await cursor.ToListAsync();
        return documents;
    }

    // public async Task UpdateOneAsync(string id, UpdateDefinition<BsonDocument> update, string collectionName)
    // {`
    //     var collection = GetCollection(collectionName);
    //     var filter = Builders<JObject>.Filter.Eq("_id", id);
    //     await collection.UpdateOneAsync(filter, update);
    // }

    // public async Task InsertOneAsync(JObject document, string collectionName)
    // {
    //     var collection = GetCollection(collectionName);
    //     await collection.InsertOneAsync(document);
    // }

    // public async Task DeleteOneAsync(string id, string collectionName)
    // {
    //     var collection = GetCollection(collectionName);
    //     var filter = Builders<JObject>.Filter.Eq("_id", id);
    //     await collection.DeleteOneAsync(filter);
    // }

    // public async Task<long> CountAsync(FilterDefinition<JObject> filter, string collectionName)
    // {
    //     var collection = GetCollection(collectionName);
    //     return await collection.CountDocumentsAsync(filter ?? Builders<JObject>.Filter.Empty);
    // }
}
