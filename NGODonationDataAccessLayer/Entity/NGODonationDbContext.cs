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
        public NGODonationDbContext(DbContextOptions<NGODonationDbContext> options):base(options) { }
        public DbSet<Users> UsersTable { get; set; }


    }
}





