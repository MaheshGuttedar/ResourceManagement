using System;
using ResourceManagement.Models.Model;

namespace ResourceManagement.DTO.Model
{
    public class EmployeeSeatDetailDTO
    {
        #region Propeties

        public int SeatId { get; set; }
        public int SeatName { get; set; }
        public SeatTypeDTO SeatType { get; set; }
        public DateTime DateOfAllocation { get; set; }
        #endregion
    }
}
