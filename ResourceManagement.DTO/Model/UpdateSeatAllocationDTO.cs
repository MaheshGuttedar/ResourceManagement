using System.ComponentModel.DataAnnotations;

namespace ResourceManagement.DTO.Model
{
    public class UpdateSeatAllocationDTO
    {
        #region Propeties

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int EmployeeId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int OldSeatId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int NewSeatId { get; set; }

        #endregion
    }
}
