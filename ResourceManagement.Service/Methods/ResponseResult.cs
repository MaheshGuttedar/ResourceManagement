using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManagement.Service.Methods
{
    public class ResponseResult
    {
        #region Propeties
        public int StatusCode { get; set; }
        public object Result { get; set; }        
        public string Errormessage { get; set; }
        #endregion

        #region Constructor
    
        public ResponseResult(int statusCode,object result, string errormassage)
        {
            StatusCode = statusCode;          
            Result = result;
            Errormessage = errormassage;

        }
        #endregion
    }
}
