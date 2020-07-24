using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagement.ResponseResult
{
    public class ResponseResult
    {
        public Exception Exception { get; set; }
        public object Result { get; set; }
    }
}
