using System;
using System.Text.Json.Nodes;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;

namespace shopsincampus.data.Interfaces;

public interface IShopRepository
{
    Task<List<JObject>> FetchAllShopsByCollegeId(string collegeId);
}
