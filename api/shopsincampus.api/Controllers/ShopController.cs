using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using shopsincampus.business;
using shopsincampus.business.Interfaces;
using shopsincampus.data.Models;

namespace shopsincampus.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopManager _shopManager;
        public ShopController(IShopManager shopManager) {
            _shopManager = shopManager;
        }

        [HttpPost]
        [Route("FetchAllShopsByCollegeId")]
        public async Task<List<Shop>> FetchAllShopsByCollegeId(FetchShopsModel parameters) {
            var response = new List<Shop>();
            var campusId = parameters.campusId;
            var collegeId = parameters.collegeId;
            if(string.IsNullOrEmpty(campusId) || string.IsNullOrEmpty(collegeId)) {
                return response;
            }
            return await _shopManager.FetchAllShopsByCollegeId(collegeId, campusId);
        }
    }
}
