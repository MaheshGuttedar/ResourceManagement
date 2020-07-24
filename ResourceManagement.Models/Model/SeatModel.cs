using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResourceManagement.Models.Model
{
   public class SeatModel
    {
        //[Required]
        //[Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int FloorId { get; set; }
        //[Required]       
        public string SeatName { get; set; }
        //[Required]
        //[Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int SeatType { get; set; }
        public bool IsAllocated { get; set; }

        public int EmployeeId { get; set; }


 

    }
}
