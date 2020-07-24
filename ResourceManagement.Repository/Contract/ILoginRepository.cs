using System.Collections.Generic;
using System.Threading.Tasks;
using ResourceManagement.Models;
using ResourceManagement.Models.Model;

namespace ResourceManagement.Repository.Contract
{
    public interface ILoginRepository
    {

        Task<bool> ValidateUser(UserModel user);
       
    }
}
