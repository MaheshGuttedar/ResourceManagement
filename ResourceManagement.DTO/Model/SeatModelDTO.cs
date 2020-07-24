using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManagement.DTO.Model
{
   public class SeatModelDTO
    {
   
            public int SeatId { get; set; }
            public int FloorId { get; set; }
            public string SeatName { get; set; }
            public int EmployeeId { get; set; }
            public int SeatType { get; set; }
            public DateTime DateOfAllocation { get; set; }
            public bool IsAllocated { get; set; }
 
    }
}
