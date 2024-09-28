using System;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using shopsincampus.data.Interfaces;
using shopsincampus.data.Models;

namespace shopsincampus.data.Repositories;

public class ShopRepository : IShopRepository
{
    private readonly IDomainModelRepository<Shop> _domainModeRepository;
    public ShopRepository(IDomainModelRepository<Shop> domainModelRepository) {
        _domainModeRepository = domainModelRepository;
    }
    public Task<List<Shop>> FetchAllShopsByCollegeId(string collegeId, string campusId)
    {
        var filter = Builders<Shop>.Filter.And(
            Builders<Shop>.Filter.Eq("collegeId", collegeId),
            Builders<Shop>.Filter.Eq("campusId", campusId)
        );        
        return _domainModeRepository.FindAllAsync(filter, "shops");
    }
}
