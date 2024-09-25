using System;
using Newtonsoft.Json.Linq;
using shopsincampus.data.Interfaces;

namespace shopsincampus.data.Repositories;

public class ShopRepository : IShopRepository
{
    public Task<List<JObject>> FetchAllShopsByCollegeId(string collegeId)
    {
        throw new NotImplementedException();
    }
}
