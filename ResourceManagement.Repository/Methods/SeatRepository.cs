using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ResourceManagement.Models.Model;
using ResourceManagement.Repository.Contract;

namespace ResourceManagement.Repository.Methods
{
    public class SeatRepository : ISeatRepository
    {
        #region Private Variables
        private readonly string _sqlConnString;
        #endregion

        #region Constructor
        public SeatRepository(string connectionstring)
        {
            _sqlConnString = connectionstring;
        }


        #endregion

        #region DataBase Methods

        
        public async Task<string> AddSeat(SeatModel seat)
        {
            using (var con = new SqlConnection(_sqlConnString))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@FloorId ", seat.FloorId);
                parameter.Add("@SeatName", seat.SeatName);
                parameter.Add("@SeatType", seat.SeatType);
                parameter.Add("@Response", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Task.Run(() => con.Execute("spSeatInsert", parameter, commandType: CommandType.StoredProcedure));
               return  parameter.Get<string>("@Response");
            }
        }

      
        public async Task<IEnumerable<SeatDetails>> GetAvailableSeats(int floorId)
        {
            using (var con = new SqlConnection(_sqlConnString))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@FloorId ", floorId);
               // parameter.Add("@SeatType", seatType);
                return await Task.Run(() => con.Query<SeatDetails>("GetAvailableSeats", parameter, commandType: CommandType.StoredProcedure).ToList());
            }
        }

       
        public async Task<string> Allocate(SeatAllocat SeatAllocat)
        {
            using (var con = new SqlConnection(_sqlConnString))
            {
               
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@employeeId", SeatAllocat.EmployeeID);
                parameter.Add("@seatId", SeatAllocat.SeatId);
               
                parameter.Add("@Response", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Task.Run(() => con.Execute("spAllocateSeat", parameter, commandType: CommandType.StoredProcedure));
                return parameter.Get<string>("@Response");
            }
        }

       
        public async Task<string> Reallocate(SeatAllocat seatAllocat)
        {
            using (var con = new SqlConnection(_sqlConnString))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@employeeId", seatAllocat.EmployeeID);
                parameter.Add("@seatId", seatAllocat.SeatId);
               
                parameter.Add("@Response", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Task.Run(() => con.Execute("spReallocateSeat", parameter, commandType: CommandType.StoredProcedure));
                return parameter.Get<string>("@Response");
            }
        }

      
        #endregion
    }
}
