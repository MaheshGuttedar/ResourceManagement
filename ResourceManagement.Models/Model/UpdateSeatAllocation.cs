using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManagement.Models.Model
{
    public class UpdateSeatAllocation
    {
        #region Propeties

        public int EmployeeId { get; set; }
        public int OldSeatId { get; set; }
        public int NewSeatId { get; set; }

        #endregion
    }
}
