using System;
using System.Collections.Generic;
using System.Text;
using ResourceManagement.Models.Model;

namespace ResourceManagement.DTO.Model
{
    public class AllEmployeeSeatDetailsDTO : EmployeeDTO
    { 
        public string EmployeeId { get; set; }
        public int SeatId { get; set; }
        public int FloorId { get; set; }
        public string SeatName { get; set; }
        public int SeatNo { get; set; }
        public SeatTypeDTO SeatTypeDTO {get;set;}
        public bool IsAllocated { get; set; }
        public DateTime DateOfAllocation { get; set; }
    }
}
