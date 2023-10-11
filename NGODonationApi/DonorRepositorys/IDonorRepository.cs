using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGODonationDataAccessLayer.Entity
{
    public interface IDonorRepository
    {
        Task<IEnumerable<Donor>> GetAllDonors();
        Task<Donor> GetDonorById(int? id);
        Task Add(Donor donor);
        Task Update(int id,Donor donor);
        Task Delete(int id);
    }
}
