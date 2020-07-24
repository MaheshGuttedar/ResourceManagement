using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ResourceManagement.Models.Model;

namespace ResourceManagement.Repository.Contract
{
    public interface IFloorRepository
    {
        Task<IEnumerable<Floor>> GetAllFloors();
    }
}
