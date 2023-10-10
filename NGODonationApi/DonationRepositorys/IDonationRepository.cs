using NGODonationDataAccessLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGODonationApi.DonationsRepositorys
{
    public interface IDonationRepository
    {
        Task<IEnumerable<Donation>> GetAllDonoations();
        Task<Donation> GetDonationById(int? id);
        Task Add(Donation donation);
        Task Update(int id, Donation donation);
        Task Delete(int id);
    }
}
