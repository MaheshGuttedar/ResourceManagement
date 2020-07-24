using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResourceManagement.DTO.Model;
using ResourceManagement.Service.Contract;

namespace ResourceManagement.Controllers
{
   
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [EnableCors]
    public class EmployeeController : ControllerBase
    {
        #region Private Variables
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;
        #endregion

        #region Constructor
        /// <summary>
        /// EmployeeController
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="employeeService"></param>
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }
        #endregion

        #region API Methods  

    
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllEmployeeDetails()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _employeeService.GetAllEmployeeDetails();
                return StatusCode(result.StatusCode, result);
                //return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        [HttpGet]
        [Authorize]
        [Route("{searchkey}/{isallocated}")]
        public async Task<IActionResult> GetAllEmployeeWithSeatDetails(string searchkey,bool? isallocated)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _employeeService.SearchAllotedEmployees(searchkey, isallocated);
                return StatusCode(result.StatusCode, result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
        #endregion
    }
}