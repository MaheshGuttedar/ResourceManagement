using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ResourceManagement.Models.Model;

namespace ResourceManagement.DTO.Model
{
    public class EmployeeDTO
    {
        #region Propeties
        [Required]
        public string USTId { get; set; }
        [Required]
        public string EmployeeName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public EmployeeTypeDTO EmployeeType { get; set; }

        [Required]
        public DateTime DateofJoining { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public bool IsAllocated { get; set; }
        #endregion
    }

 
}
