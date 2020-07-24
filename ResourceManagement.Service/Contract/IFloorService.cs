using System.Collections.Generic;
using System.Threading.Tasks;
using ResourceManagement.DTO.Model;
using ResourceManagement.Service.Methods;

namespace ResourceManagement.Service.Contract
{
    public interface IFloorService
    {
      
        Task<ResponseResult> GetAllFloors();
    }
}
