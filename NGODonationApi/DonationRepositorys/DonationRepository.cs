﻿using Microsoft.EntityFrameworkCore;
using NGODonationDataAccessLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGODonationApi.DonationsRepositorys
{
    public class DonationRepository : IDonationRepository
    {
        private readonly NGODonationDbContext? _donationContext;

        public DonationRepository()
        {

        }

        public DonationRepository(NGODonationDbContext _donationContext)
        {
            this._donationContext = _donationContext;
        }


        public async Task<IEnumerable<Donation>> GetAllDonoations()
        {
            try
            {
                var donation = await _donationContext.Donations.ToListAsync();
                return donation;
            }
            catch 
            {
                throw;
            }
        }

        public async Task Add(Donation donation)
        {
            _donationContext.Add(donation);
            try
            {
                _donationContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(int id, Donation donation)
        {
            try
            {
                var Don = _donationContext.Donations.Find(id);
                if (Don != null)
                {
                    Don.Email = donation.Email;
                    Don.Date = donation.Date;
                    Don.Amount = donation.Amount;
                    Don.DonationType = donation.DonationType;
                    _donationContext.SaveChanges();
                }
            }
            catch 
            {
                throw;
            }
            
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }        

        public Task<Donation> GetDonationById(int? id)
        {
            throw new System.NotImplementedException();
        }
    }
}
