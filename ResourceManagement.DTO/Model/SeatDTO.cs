using System.ComponentModel.DataAnnotations;
using ResourceManagement.Models.Model;

namespace ResourceManagement.DTO.Model
{
    public class SeatDTO
    {
        #region Propeties'

        [Required]       
        public SeatTypeDTO SeatType { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int FloorNo { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int SeatNo { get; set; }

        #endregion
    }
}
