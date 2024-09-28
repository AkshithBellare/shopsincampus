using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopsincampus.business.Interfaces;
using shopsincampus.data.Models;

namespace shopsincampus.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampusController : ControllerBase
    {
        private readonly ICampusManager _campusManager;
        public CampusController(ICampusManager campusManager) {
            _campusManager = campusManager;
        }

        [HttpGet]
        [Route("FetchAllCampuses")]
        public async Task<List<Campus>> FetchAllCampuses() {
            return await _campusManager.FetchAllCampuses();
        }

        [HttpGet]
        [Route("FetchAllCampusesByCollegeId")]
        public async Task<List<Campus>> FetchAllCampusesByCollegeId(string collegeId) {
            return await _campusManager.FetchAllCampusesByCollegeId(collegeId);
        }

        [HttpPost]
        [Route("CreateCampus")]
        public async Task<Campus> CreateCampus(Campus newCampus) {
            newCampus.Id = Guid.NewGuid().ToString();
            return await _campusManager.CreateCampus(newCampus);
        }
    }
}
