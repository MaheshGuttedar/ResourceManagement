using System.Collections.Generic;
using System.Threading.Tasks;
using ResourceManagement.Models.Model;

namespace ResourceManagement.Repository.Contract
{
    public interface IEmployeeRepository
    {
       
        Task<IEnumerable<Employee>> GetAllEmployeeDetails();
        Task<IEnumerable<Employee>> SearchAllotedEmployees(string searchkey,bool? isallocated);
    }
}
