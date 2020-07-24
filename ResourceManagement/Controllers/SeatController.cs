using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResourceManagement.DTO.Model;
using ResourceManagement.Models.Model;
using ResourceManagement.Service.Contract;

namespace ResourceManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [EnableCors]
    public class SeatController : ControllerBase
    {
        #region Private Variables
        private readonly ILogger _logger;
        private readonly ISeatService _seatService;
        #endregion

        #region Constructor
        public SeatController(ILogger<SeatController> logger, ISeatService seatService)
        {
            _logger = logger;
            _seatService = seatService;
        }
        #endregion

        #region API Methods        

  
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Seat([FromBody]SeatModel seat)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _seatService.AddSeat(seat);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("{floorId}")]
        public async Task<IActionResult> GetAvailableSeats(int floorId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _seatService.GetAvailableSeats(floorId);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        [Authorize]
        [HttpPut]
        [Route("Allocate")]
        public async Task<IActionResult> Allocate( [FromBody]SeatAllocat SeatAllocat)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _seatService.Allocate(SeatAllocat);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        [Authorize]
        [HttpPut]
        [Route("Reallocate")]
       public async Task<IActionResult> Reallocate([FromBody]SeatAllocat seatAllocat)
        { 
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _seatService.Reallocate(seatAllocat);
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