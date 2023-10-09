using NGODonationDataAccessLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGODonationApi.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetAllUsers();
        Task<Users> GetUsersById(int? id);
        Task AddUsers(Users user);
        Task Update(int id, Users users);
        Task Delete(int id);





    }
}
