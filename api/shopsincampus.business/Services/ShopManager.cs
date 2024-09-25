﻿namespace shopsincampus.business;

using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using shopsincampus.business.Interfaces;
using shopsincampus.data.Interfaces;

public class ShopManager : IShopManager
{
    private readonly IShopRepository _shopRepository;

    public ShopManager(IShopRepository shopRepository) {
        _shopRepository = shopRepository;
    }
    public async Task<List<JObject>> FetchAllShopsByCollegeId(string collegeId)
    {
        return await _shopRepository.FetchAllShopsByCollegeId(collegeId);;
    }
}
