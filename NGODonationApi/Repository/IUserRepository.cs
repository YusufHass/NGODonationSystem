using NGODonationDataAccessLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGODonationApi.Repository
{
    public interface IUserRepositoryRepository
    {
        IEnumerable<Users> GetRoles();
        Task<IEnumerable<Users>> GetAllUsers();
        Task<Users> GetUsersById(int? id);
        Task AddUsers(Users user);
        Task Update(int id, Users users);
        Task Delete(int id);
        Task<IEnumerable<Users>> getuser();
        Task<Users> AuthenticateUser(string email, string passcode);






    }
}
