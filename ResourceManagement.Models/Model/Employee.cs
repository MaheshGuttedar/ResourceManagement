using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManagement.Models.Model
{
    public class Employee
    {
        #region Propeties

        public int EmployeeId { get; set; }
        public string USTId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public DateTime DateofJoining { get; set; }
        public bool IsActive { get; set; }
        public bool IsAllocated { get; set; }

        #endregion
    }
}
