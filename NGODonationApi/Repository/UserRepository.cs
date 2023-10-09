using Microsoft.EntityFrameworkCore;
using NGODonationDataAccessLayer.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGODonationApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly NGODonationDbContext _context;
        public UserRepository(NGODonationDbContext dbContext) 
        {
            this._context = dbContext;
        }
       public async Task<IEnumerable<Users>>GetAllUsers()
        {
            var users = await _context.UsersTable.ToListAsync();
            return users;
        }

        public async Task<Users> GetUsersById(int? id)
        {
            try
            {
                Users user = await _context.UsersTable.FindAsync(id);
                if (user == null)
                {
                    return null;
                }
                return user;
            }
            catch
            {
                throw;
            }
        }
        public async Task AddUsers(Users user)
        {
            _context.UsersTable.Add(user);
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(int id, Users users)
        {
            var result = _context.UsersTable.Find(id);
            if (result != null)
            {
                result.FirstName = users.FirstName;
                result.LastName = users.LastName;
                result.Email = users.Email;
                result.Password = users.Password;
                result.Role = users.Role;
                _context.SaveChanges();
            }

            
        }

       public async Task Delete(int id)
        {
            Users user = await _context.UsersTable.FindAsync(id);
            if (user != null)
            {
                _context.UsersTable.Remove(user);
                _context.SaveChanges();
            }
        }


    }
}
