using System;
using shopsincampus.data.Models;

namespace shopsincampus.data.Interfaces;

public interface ICampusRepository
{
    Task<List<Campus>> FetchAllCampuses();

    Task<Campus> CreateCampus(Campus newCampus);

    Task<List<Campus>> FetchAllCampusesByCollegeId(string collegeId);

}
