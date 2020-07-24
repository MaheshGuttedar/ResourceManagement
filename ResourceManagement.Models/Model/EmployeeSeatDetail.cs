using System;

namespace ResourceManagement.Models.Model
{
    public class EmployeeSeatDetail
    {
        #region Propeties

        public int SeatId { get; set; }
        public int SeatName { get; set; }
        public SeatType SeatType { get; set; }
        public DateTime DateOfAllocation { get; set; }

        #endregion
    }
}
