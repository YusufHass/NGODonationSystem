using NGODonationDataAccessLayer.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NGODonationApi.LoginRepository
{
    public class AuthenticateLogin : ILogin
    {
        private readonly NGODonationDbContext _context;
        public AuthenticateLogin(NGODonationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Users>> getuser()
        {
            return await _context.UsersTable.ToListAsync();
        }
        public async Task<Users> AuthenticateUser(string email, string passcode)
        {
            var succeeed = await _context.UsersTable.FirstOrDefaultAsync(authUser => authUser.Email == email && authUser.Password== passcode);


            return succeeed;
        }


    }
}
