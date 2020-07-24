using System.Collections.Generic;
using System.Threading.Tasks;
using ResourceManagement.Models.Model;
namespace ResourceManagement.Repository.Contract
{
    public interface ISeatRepository
    {
        Task<string> AddSeat(SeatModel seat);
        Task<IEnumerable<SeatDetails>> GetAvailableSeats(int floorId);
        Task<string> Allocate(SeatAllocat SeatAllocat);
        Task<string> Reallocate(SeatAllocat seatAllocat);
    }
}
