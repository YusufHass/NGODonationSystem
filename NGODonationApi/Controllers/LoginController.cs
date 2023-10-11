/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NGODonationApi.Repository;
using NGODonationDataAccessLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGODonationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserRepositoryRepository _userRepository;

        public LoginController(IUserRepositoryRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        [Route("api/Users/Get")]
        public async Task<IEnumerable<Users>> Get()
        {
            return await _userRepository.u;
        }
    }
}
*/