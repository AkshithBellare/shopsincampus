using System;
using MongoDB.Driver;
using shopsincampus.data.Interfaces;
using shopsincampus.data.Models;

namespace shopsincampus.data.Repositories;

public class CampusRepository : ICampusRepository
{
    private readonly IDomainModelRepository<Campus> _domainModeRepository;
    public CampusRepository(IDomainModelRepository<Campus> domainModelRepository) {
        _domainModeRepository = domainModelRepository;
    }

    public Task<List<Campus>> FetchAllCampuses()
    {
        var filter = Builders<Campus>.Filter.Empty;
        return _domainModeRepository.FindAllAsync(filter, "campuses");
    }

    public async Task<Campus> CreateCampus(Campus newCampus)
    {
        await _domainModeRepository.InsertOneAsync(newCampus, "campuses");
        return newCampus;
    }

    public Task<List<Campus>> FetchAllCampusesByCollegeId(string collegeId)
    {
        var filter = Builders<Campus>.Filter.Eq("collegeId", collegeId);
        return _domainModeRepository.FindAllAsync(filter, "campuses");
    }
}
