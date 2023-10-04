using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGODonationDataAccessLayer.Entity
{
    public class NGODonationDbContext: DbContext 
    {
        public NGODonationDbContext(DbContextOptions<NGODonationDbContext> options):base(options) { }
        public DbSet<Users> UsersTable { get; set; }
    }
}
