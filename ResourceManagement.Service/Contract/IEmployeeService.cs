using System.Threading.Tasks;
using ResourceManagement.DTO.Model;
using ResourceManagement.Service.Methods;

namespace ResourceManagement.Service.Contract
{
    public interface IEmployeeService
    {
             
        Task<ResponseResult> GetAllEmployeeDetails();
                
        Task<ResponseResult> SearchAllotedEmployees(string searchkey,bool? isallocated);
    }

 
}
