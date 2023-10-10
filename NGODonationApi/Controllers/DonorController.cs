using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NGODonationDataAccessLayer.Entity;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGODonationApi.Controllers
{
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorRepository _donorRepository;

        public DonorController(IDonorRepository _donorRepository)
        {
            this._donorRepository = _donorRepository;
        }

        [HttpGet]
        [Route("api/Donors/Get")]
        public async Task<IEnumerable<Donor>> Get() 
        { 
            return await _donorRepository.GetAllDonors();
        }

        [HttpGet]
        [Route("api/Donors/Details/{id}")]
        public async Task<Donor> Details(int? id)
        {
            var result = await _donorRepository.GetDonorById(id);
            return result;
        }

        [HttpPost]
        [Route("api/Donors/Create")]
        public async Task CreateAsync([FromBody] Donor donor) 
        { 
            if(ModelState.IsValid) 
            {
                await _donorRepository.Add(donor);
            }
        }
    }
}
