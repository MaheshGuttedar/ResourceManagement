using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ResourceManagement.Models.Model;
using ResourceManagement.Repository.Contract;

namespace ResourceManagement.Repository.Methods
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _sqlConnString;
       
    
      
        
        
        public EmployeeRepository(string connectionstring)
        {
            _sqlConnString = connectionstring;
        }
      

        #region DataBase Methods

   
        public async Task<IEnumerable<Employee>> GetAllEmployeeDetails()
        {
            using (var con = new SqlConnection(_sqlConnString))
            {
                return await Task.Run(() => con.Query<Employee>("spEmployeeSelect", commandType: CommandType.StoredProcedure).ToList());
            }
        }

       

        public async Task<IEnumerable<Employee>> SearchAllotedEmployees(string searchkey,bool? isallocated)
        {
            using (var con = new SqlConnection(_sqlConnString))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@SearchKey", searchkey);
                parameter.Add("@Isallocated", isallocated);
                return await Task.Run(() => con.Query<Employee>("spEmployeeSearch", parameter,commandType: CommandType.StoredProcedure).ToList());
            }
        }

        #endregion
    }
}
