using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NGODonationApi.DonationsRepositorys;
using NGODonationDataAccessLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGODonationApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IDonationRepository _donationRepository;

        public DonationController(IDonationRepository donationRepository) => _donationRepository = donationRepository;

        [HttpGet]
        [Route("api/Donations/Get")]
        public async Task<IEnumerable<Donation>> Get() => await _donationRepository.GetAllDonoations();

        [HttpPost]
        [Route("api/Donations/Create")]
        public async Task CreateAsync([FromBody] Donation donation)
        {
            if (ModelState.IsValid)
            {
                await _donationRepository.Add(donation);
            }
        }

        [HttpPut]
        [Route("api/Donations/Edit/{id}")]
        public async Task EditAsync(int id, [FromBody] Donation donation) 
        {
            if (!ModelState.IsValid) 
            {
                await _donationRepository.Update(id, donation);
            }
        }

        [HttpDelete]
        [Route("api/Donations/Delete/{id}")]
        public async Task DeleteAsync(int id) 
        { 
            await _donationRepository.Delete(id);
        }

    }
}
