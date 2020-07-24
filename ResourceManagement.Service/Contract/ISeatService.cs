using System.Collections.Generic;
using System.Threading.Tasks;
using ResourceManagement.DTO.Model;
using ResourceManagement.Models.Model;
using ResourceManagement.Service.Methods;

namespace ResourceManagement.Service.Contract
{
    public interface ISeatService
    {
       
        Task<ResponseResult> AddSeat(SeatModel seat);

       
        Task<ResponseResult> GetAvailableSeats(int floorId);

       
        Task<ResponseResult> Allocate(SeatAllocat SeatAllocat);

    
        Task<ResponseResult> Reallocate(SeatAllocat SeatAllocat);
    }
}
