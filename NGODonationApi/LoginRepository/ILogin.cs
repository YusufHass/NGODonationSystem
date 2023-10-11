using NGODonationDataAccessLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGODonationApi.LoginRepository
{
    public interface ILogin
    {
        Task<IEnumerable<Users>> getuser();
        Task<Users> AuthenticateUser(string email, string passcode);

    }
}
