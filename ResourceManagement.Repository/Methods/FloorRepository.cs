using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagement.Models.Model;
using ResourceManagement.Repository.Contract;

namespace ResourceManagement.Repository.Methods
{
    public class FloorRepository : IFloorRepository
    {
        #region Private Variables
        private readonly string _sqlConnString;
        #endregion

        #region Constructor
        /// <summary>
        /// FloorRepository
        /// </summary>
        /// <param name="connectionstring"></param>
        public FloorRepository(string connectionstring)
        {
            _sqlConnString = connectionstring;
        }
        #endregion

        #region DataBase Methods

        /// <summary>
        /// Get Floors
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Floor>> GetAllFloors()
        {
            using (var con = new SqlConnection(_sqlConnString))
            {
                return await Task.Run(() => con.Query<Floor>("spFloor", CommandType.StoredProcedure).ToList());                
            }
        }

        #endregion
    }
}
