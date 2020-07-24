using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManagement.Models.Model
{
    public class Floor
    {
        #region Propeties

        public int FloorId { get; set; }
        public int FloorNo { get; set; }
        public int TotalNoSeats { get; set; }
        public bool IsAvailable { get; set; }

        #endregion
    }
}
