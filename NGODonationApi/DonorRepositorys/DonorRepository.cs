using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGODonationDataAccessLayer.Entity
{
    internal class DonorRepository : IDonorRepository
    {
        private readonly NGODonationDbContext _dbDonorContext;

        public DonorRepository()
        {
            
        }
        public DonorRepository(NGODonationDbContext _dbDonorContext)
        {
            this._dbDonorContext = _dbDonorContext;
        }
       
        public async Task<IEnumerable<Donor>> GetAllDonors()
        {
            try 
            {
                var donors = await _dbDonorContext.Donors.ToListAsync();
                return donors;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<Donor> GetDonorById(int id)
        {
            try
            {
                Donor donor = await _dbDonorContext.Donors.FindAsync(id);
                if( donor == null )
                { 
                    return null;
                }
                return donor;
            }
            catch 
            {
                throw;
            }
        }
        public async Task Add(Donor donor)
        {
            _dbDonorContext.Donors.Add(donor);
            try 
            {
                _dbDonorContext.SaveChanges();
            }
            catch 
            {
                throw;
            }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }             

        public Task Update(int id, Donor donor)
        {
            throw new NotImplementedException();
        }

        public Task<Donor> GetDonorById(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
