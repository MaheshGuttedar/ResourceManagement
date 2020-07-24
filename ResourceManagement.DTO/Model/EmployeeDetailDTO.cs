using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManagement.DTO.Model
{
    public class EmployeeDetailDTO
    {
        #region Propeties
        public int EmployeeId { get; set; }
        public string USTId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public bool IsAllocated { get; set; }
        public int  EmployeeType { get; set; }
        #endregion
    }
}
