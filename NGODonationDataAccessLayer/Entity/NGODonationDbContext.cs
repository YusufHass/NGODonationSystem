//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NGODonationDataAccessLayer.Entity
//{
//    public class NGODonationDbContext: DbContext 
//    {

//        public NGODonationDbContext(DbContextOptions<NGODonationDbContext> options):
//            base(options) 
//        {

//        }
//        public DbSet<Users> Users { get; set; }                     // No need for suffix Table
//        public DbSet<Donor> Donors { get; set; }
//        public DbSet<Donation> Donations { get; set; }

//    }
//}
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGODonationDataAccessLayer.Entity
{
    public class NGODonationDbContext: IdentityDbContext
    {
        public NGODonationDbContext(DbContextOptions<NGODonationDbContext> options):
            base(options) 
        {
            
        }
        public DbSet<Users> UsersTable { get; set; }                     // No need for suffix Table
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }
    }
}





