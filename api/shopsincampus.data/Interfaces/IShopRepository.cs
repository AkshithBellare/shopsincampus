using System;
using System.Text.Json.Nodes;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using shopsincampus.data.Models;

namespace shopsincampus.data.Interfaces;

public interface IShopRepository
{
    Task<List<Shop>> FetchAllShopsByCollegeId(string collegeId);
}
