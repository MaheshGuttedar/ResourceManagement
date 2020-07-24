using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManagement.Models.Model
{
   public class EmpSeatDetails : Employee
    {
        public int SeatId { get; set; }
        public int FloorId { get; set; }
        public string SeatName { get; set; }
        public int SeatNo { get; set; }
        public SeatType SeatTypeDTO { get; set; }
        public bool IsAllocated { get; set; }
        public DateTime DateOfAllocation { get; set; }
    }
}
