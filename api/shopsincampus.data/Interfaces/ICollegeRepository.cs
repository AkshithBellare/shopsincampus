using System;
using shopsincampus.data.Models;

namespace shopsincampus.data.Interfaces;

public interface ICollegeRepository
{
    Task<List<College>> FetchAllColleges();

    Task<College> CreateCollege(College newCollege);
}
