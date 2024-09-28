using System;
using shopsincampus.business.Interfaces;
using shopsincampus.data.Interfaces;
using shopsincampus.data.Models;

namespace shopsincampus.business.Services;

public class CampusManager : ICampusManager
{
    private readonly ICampusRepository _campusRepository;

    public CampusManager(ICampusRepository campusRepository) {
        _campusRepository = campusRepository;
    }

    public async Task<Campus> CreateCampus(Campus newCollege)
    {
        return await _campusRepository.CreateCampus(newCollege);
    }

    public async Task<List<Campus>> FetchAllCampuses()
    {
        return await _campusRepository.FetchAllCampuses();
    }

    public async Task<List<Campus>> FetchAllCampusesByCollegeId(string collegeId)
    {
        return await _campusRepository.FetchAllCampusesByCollegeId(collegeId);
    }
}
