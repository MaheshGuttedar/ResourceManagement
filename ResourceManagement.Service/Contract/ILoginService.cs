using System.Threading.Tasks;
using ResourceManagement.DTO.Model;
using ResourceManagement.Models;
using ResourceManagement.Service.Methods;

namespace ResourceManagement.Service.Contract
{
    public interface ILoginService
    {
             
        Task<bool> ValidateUser(UserModel userModel);
                
       
    }

 
}
