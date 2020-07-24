using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResourceManagement.Service.Contract;

namespace ResourceManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class FloorController : ControllerBase
    {

        #region Private Variables
        private readonly ILogger _logger;
        private readonly IFloorService _floorService;
        #endregion

        #region Constructor
        /// <summary>
        /// FloorController
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="floorService"></param>
        public FloorController(ILogger<FloorController> logger, IFloorService floorService)
        {
            _logger = logger;
            _floorService = floorService;
        }
        #endregion

        #region  API Methods 

  
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetALLFloors()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _floorService.GetAllFloors();
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