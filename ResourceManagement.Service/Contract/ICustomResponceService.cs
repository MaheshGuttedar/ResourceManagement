using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using USTEmployeeSeatAllocation.Service.Methods;

namespace USTEmployeeSeatAllocation.Service.Contract
{
    public interface ICustomResponceService
    {

        Task<CustomResult> GetCustomeResponce<T>(T obj, int? statusCode);
    }
}
