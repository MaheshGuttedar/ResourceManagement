using System;

namespace ResourceManagement.Models.Model
{
    public class SeatDTO
    {
      

        public SeatType SeatType { get; set; }
        public int FloorNo { get; set; }
        public int SeatNo { get; set; }
        public bool IsAllocated { get; set; } = false;

  
    }

    public class SeatAllocat
    {


        public int SeatId { get; set; }
        public int EmployeeID { get; set; }
    
    }
}
