using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NGODonationApi.Repository;
using NGODonationDataAccessLayer.Entity;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGODonationApi.Controllers
{
/*    [Route("api/[controller]")]
*/    
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserAPIController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        [Route("api/Users/Get")]
        public async Task<IEnumerable<Users>>Get()
        {
            return await _userRepository.GetAllUsers();
        }

        [HttpGet]
        [Route("api/Users/Details/{id}")]
        public async Task<Users> Details(int? id)
        {
            var result = await _userRepository.GetUsersById(id);
            return result;
        }

        [HttpPost]
        [Route("api/Users/Create")]
        public async Task CreateAsync([FromBody] Users users)
        {
            if(ModelState.IsValid)
            {
                await _userRepository.AddUsers(users);
            }
        }
        [HttpPut]
        [Route("api/Users/Edit/{id}")]
        public async Task EditAsync(int id, Users users)
        {
            if(ModelState.IsValid)
            {
                await _userRepository.Update(id, users);
            }
        }

        [HttpDelete]
        [Route("api/Users/Delete/{id}")]
        public async Task DeleteConfirmAsync(int id)
        {
            await _userRepository.Delete(id);
        }

    }
}
