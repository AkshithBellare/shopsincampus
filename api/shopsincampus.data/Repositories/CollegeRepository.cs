using System;
using MongoDB.Driver;
using shopsincampus.data.Interfaces;

namespace shopsincampus.data.Models;

public class CollegeRepository : ICollegeRepository
{
    private readonly IDomainModelRepository<College> _domainModeRepository;
    public CollegeRepository(IDomainModelRepository<College> domainModelRepository) {
        _domainModeRepository = domainModelRepository;
    }

    public async Task<College> CreateCollege(College newCollege)
    {
        await _domainModeRepository.InsertOneAsync(newCollege, "colleges");
        return newCollege;
    }

    public Task<List<College>> FetchAllColleges()
    {
        var filter = Builders<College>.Filter.Empty;
        return _domainModeRepository.FindAllAsync(filter, "colleges");
    }
}
