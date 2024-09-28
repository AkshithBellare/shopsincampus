using System;
using shopsincampus.data.Models;

namespace shopsincampus.business.Interfaces;

public interface ICampusManager
{
    Task<List<Campus>> FetchAllCampuses();

    Task<List<Campus>> FetchAllCampusesByCollegeId(string collegeId);

    Task<Campus> CreateCampus(Campus newCollege);
}
