using System;
using System.Text.Json.Nodes;
using shopsincampus.data.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using shopsincampus.data.Models;

namespace shopsincampus.business.Interfaces;

public interface IShopManager
{
    Task<List<Shop>> FetchAllShopsByCollegeId(string collegeId, string campusId);

    Task<Shop> CreateShop(Shop newShop);
}
