using System;
using shopsincampus.data.Interfaces;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using ZstdSharp.Unsafe;
namespace shopsincampus.data.Repositories;

public class DomainModelRepository : IDomainModelRepository
{
    private readonly IMongoDatabase _database;
    private readonly Dictionary<string, IMongoCollection<JObject>> _collectionCache;

    public DomainModelRepository(IMongoDatabase database)
    {
        _database = database;
        _collectionCache = new Dictionary<string, IMongoCollection<JObject>>();
    }

    public IMongoCollection<JObject> GetCollection(string collectionName)
    {
        if (!_collectionCache.TryGetValue(collectionName, out var collection))
        {
            collection = _database.GetCollection<JObject>(collectionName);
            _collectionCache[collectionName] = collection; // Cache the collection
        }
        return collection;
    }

    public async Task<JObject> FindByIdAsync(string id, string collectionName)
    {
        var filter = Builders<JObject>.Filter.Eq("_id", id);
        var collection = GetCollection(collectionName);
        return await collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<JObject> FindOneAsync(FilterDefinition<JObject> filter, string collectionName)
    {
        var collection = GetCollection(collectionName);
        return await collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<List<JObject>> FindAllAsync(FilterDefinition<JObject> filter, string collectionName)
    {
        var collection = GetCollection(collectionName);
        return await collection.Find(filter ?? Builders<JObject>.Filter.Empty).ToListAsync();
    }

    public async Task UpdateOneAsync(string id, UpdateDefinition<JObject> update, string collectionName)
    {
        var collection = GetCollection(collectionName);
        var filter = Builders<JObject>.Filter.Eq("_id", id);
        await collection.UpdateOneAsync(filter, update);
    }

    public async Task InsertOneAsync(JObject document, string collectionName)
    {
        var collection = GetCollection(collectionName);
        await collection.InsertOneAsync(document);
    }

    public async Task DeleteOneAsync(string id, string collectionName)
    {
        var collection = GetCollection(collectionName);
        var filter = Builders<JObject>.Filter.Eq("_id", id);
        await collection.DeleteOneAsync(filter);
    }

    public async Task<long> CountAsync(FilterDefinition<JObject> filter, string collectionName)
    {
        var collection = GetCollection(collectionName);
        return await collection.CountDocumentsAsync(filter ?? Builders<JObject>.Filter.Empty);
    }
}
