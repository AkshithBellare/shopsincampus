using System;
using shopsincampus.data.Models;

namespace shopsincampus.business.Interfaces;

public interface ICollegeManager
{
    Task<List<College>> FetchAllColleges();

    Task<College> CreateCollege(College newCollege);

}
