using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ResourceManagement.ResponseResult
{
    public class ResponseActionResult : IActionResult
    {
        private readonly ResponseResult _result;
        private readonly HttpStatusCode _statusCode;

        public ResponseActionResult(ResponseResult result, HttpStatusCode statusCode)
        {
            _result = result;
            _statusCode = statusCode;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_result.Exception ?? _result.Result)
            {
                StatusCode = _result.Exception != null
                    ? StatusCodes.Status500InternalServerError
                    : GetStatusCodes(_statusCode)
            };

            await objectResult.ExecuteResultAsync(context);
        }


       private static int GetStatusCodes(HttpStatusCode statusCodes)
        {
            switch (statusCodes)
            {
                case HttpStatusCode.OK:
                    return StatusCodes.Status200OK;

                case HttpStatusCode.Created:
                    return StatusCodes.Status201Created;

                case HttpStatusCode.NotFound:
                    return StatusCodes.Status404NotFound ;

                default:
                    return StatusCodes.Status500InternalServerError;
            }

        }
    }
}
