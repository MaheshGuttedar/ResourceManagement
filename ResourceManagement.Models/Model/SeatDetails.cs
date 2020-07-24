using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManagement.Models.Model
{
    public class SeatDetails
    {
        public int SeatId { get; set; }
        public string SeatName { get; set; } 
        public int SeatType { get; set; }
        public bool IsAllocated { get; set; }
        public int EmployeeId { get; set; }
    }
}
