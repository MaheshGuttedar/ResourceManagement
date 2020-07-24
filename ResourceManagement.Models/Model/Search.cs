using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManagement.Models.Model
{
    public class Search
    {
        public string SearchKey { get; set; } = null;
        public string EmployeeId { get; set; } = null;
        public string USTId { get; set; } = null;
        public string EmployeeName { get; set; } = null;       
        public string Email { get; set; } = null;
        public EmployeeType? EmployeeType { get; set; } = null;
        public DateTime? DateofJoining { get; set; } = null;
        public bool? IsActive { get; set; } = null;
        public int? SeatId { get; set; } = null;
        public int? FloorId { get; set; } = null;
        public string SeatName { get; set; } = null;
        public int? SeatNo { get; set; } = null;
        public SeatType? SeatType { get; set; } = null;
        public bool? IsAllocated { get; set; } = null;
        public DateTime? DateOfAllocation { get; set; } = null;
    }
}
