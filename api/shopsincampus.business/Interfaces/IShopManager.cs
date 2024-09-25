using System;
using System.Text.Json.Nodes;
using shopsincampus.data.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace shopsincampus.business.Interfaces;

public interface IShopManager
{
    Task<List<JObject>> FetchAllShopsByCollegeId(string collegeId);
}
