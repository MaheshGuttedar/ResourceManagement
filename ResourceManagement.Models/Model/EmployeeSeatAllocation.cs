using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManagement.Models.Model
{
    public class EmployeeSeatAllocation 
    {
        #region Propeties

        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public EmployeeType EmpType { get; set; }
        public string EmpSeat { get; set; }
        public string AllocationDate { get; set; }
        public bool IsActive { get; set; }

        #endregion
    }
}
