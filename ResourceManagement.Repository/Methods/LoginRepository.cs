using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ResourceManagement.Models.Model;
using ResourceManagement.Repository.Contract;
using ResourceManagement.Models;

namespace ResourceManagement.Repository.Methods
{
    public class LoginRepository : ILoginRepository
    {
        #region Private Variables
        private readonly string _sqlConnString;


        #endregion

        #region Constructor
        /// <summary>
        /// LoginRepository
        /// </summary>
        /// <param name="connectionstring"></param>
        public LoginRepository(string connectionstring)
        {
            _sqlConnString = connectionstring;
        }
        #endregion

        #region DataBase Methods


        /// <summary>
        /// ValidateUserls
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ValidateUser(UserModel user)
        {
            //using (var con = new SqlConnection(_sqlConnString))
            //{
            //    DynamicParameters ObjParm = new DynamicParameters();
            //    ObjParm.Add("@userid", user.Username);
            //    ObjParm.Add("@password", user.Password);
            //    //ObjParm.Add("@response", dbType: DbType.String, direction: ParameterDirection.Output, size: 150);
            //    return await Task.Run(() => con.Query<UserModel>("spValidateUser", ObjParm,commandType: CommandType.StoredProcedure).ToList());
            //}
            using (var con = new SqlConnection(_sqlConnString))
            {

                DynamicParameters objparm = new DynamicParameters();
                objparm.Add("@userId", user.Username);
                objparm.Add("@password", user.Password);
                objparm.Add("@response", dbType: DbType.Boolean, direction: ParameterDirection.Output, size: 150);
                con.Open();
                con.Execute("spvalidateuser", objparm, commandType: CommandType.StoredProcedure);
                bool response = objparm.Get<bool>("@response");
                con.Close();
                return response;
            }

        }


        #endregion
    }
}
