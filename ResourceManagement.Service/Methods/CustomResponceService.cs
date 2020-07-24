//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using USTEmployeeSeatAllocation.DTO.Model;
//using USTEmployeeSeatAllocation.Service.Contract;

//namespace USTEmployeeSeatAllocation.Service.Methods
//{
//    public class CustomResponceService : ICustomResponceService
//    {
//        #region Private Variables
//        private readonly ILogger _logger;
//        #endregion

//        public CustomResponceService(ILogger<CustomResponceService> logger)
//        {
//            _logger = logger;
//        }

//        public async Task<CustomResult> GetCustomeResponce<T>(T obj,string comareString=null , int? statusCode=null)
//        {
//            dynamic result = null;
//            try
//            {

//                var type = typeof(T);
//                if(type==typeof(string))
//                {
//                    if (obj.Equals(comareString))
//                    {
//                        result = await Task.Run(() => new CustomResult(obj, null, statusCode));
//                    }
//                    else
//                    {
//                        result = await Task.Run(() => new CustomResult(null, obj.ToString(), statusCode));
//                    }
//                }
//                else
//                {
//                    if()
//                }

//                result
//                    //var res = obj is string;
//                    //if(obj is string)
//                    //{
//                    //    if (obj.Equals(Constant.RecordInserted))
//                    //    {
//                    //        result = await Task.Run(() => new CustomResult(null, obj,201));
//                    //    }
//                    //    else
//                    //    {
//                    //        result = await Task.Run(() => new CustomResult(null, obj, 500));
//                    //    }
//                    //}
                    
                 
                
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex.Message);
//                throw ex;
//            }
           
//}
//        }
//    }
//}
