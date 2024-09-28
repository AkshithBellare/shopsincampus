using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopsincampus.business.Interfaces;
using shopsincampus.data.Models;

namespace shopsincampus.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeManager _collegeManager;
        public CollegeController(ICollegeManager collegeManager) {
            _collegeManager = collegeManager;
        }

        [HttpGet]
        [Route("FetchAllColleges")]
        public async Task<List<College>> FetchAllColleges() {
            return await _collegeManager.FetchAllColleges();
        }

        [HttpPost]
        [Route("CreateCollege")]
        public async Task<College> CreateCollege(College newCollege) {
            newCollege.Id = Guid.NewGuid().ToString();
            return await _collegeManager.CreateCollege(newCollege);
        }
    }
}
