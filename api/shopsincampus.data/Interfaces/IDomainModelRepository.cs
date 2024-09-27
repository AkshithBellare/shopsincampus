using System;
using System.Text.Json.Nodes;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
namespace shopsincampus.data.Interfaces;

public interface IDomainModelRepository<T> where T : class
{
    // Task<JObject> FindByIdAsync(string id, string collectionName);

    //  Task<JObject> FindOneAsync(FilterDefinition<JObject> filter, string collectionName);

    Task<List<T>> FindAllAsync(FilterDefinition<T> filter, string collectionName);

    // Task UpdateOneAsync(string id, UpdateDefinition<JObject> update,string collectionName);

    // Task InsertOneAsync(JObject document,string collectionName);

    // Task DeleteOneAsync(string id,string collectionName);

    // Task<long> CountAsync(FilterDefinition<JObject> filter,string collectionName);

}
