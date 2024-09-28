using System;
using shopsincampus.business.Interfaces;
using shopsincampus.data.Interfaces;
using shopsincampus.data.Models;

namespace shopsincampus.business.Services;

public class CollegeManager : ICollegeManager
{
    private readonly ICollegeRepository _collegeRepository;

    public CollegeManager(ICollegeRepository collegeRepository) {
        _collegeRepository = collegeRepository;
    }

    public async Task<College> CreateCollege(College newCollege)
    {
        return await _collegeRepository.CreateCollege(newCollege);
    }

    public Task<List<College>> FetchAllColleges()
    {
        return _collegeRepository.FetchAllColleges();
    }
}
