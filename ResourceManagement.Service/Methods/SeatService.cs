using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagement.DTO.Model;
using ResourceManagement.Models.Model;
using ResourceManagement.Repository.Contract;
using ResourceManagement.Service.Contract;
 

namespace ResourceManagement.Service.Methods
{
    public class SeatService : ISeatService
    {
        #region Private Variables
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public SeatService(ILogger<SeatService> logger,IMapper mapper,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        #endregion

        #region Service Methods
 
        public async Task<ResponseResult> AddSeat(SeatModel seat)
        {
            var res = await _unitOfWork.SeatRepository.AddSeat(_mapper.Map<SeatModel>(seat));

            if (res != null && res.Equals(Constant.AddSeat))
                return new ResponseResult(201,res, null);
            else if (res != null && res.Equals(Constant.SeatExists))
                return new ResponseResult(403, res,null);
            else if (res != null && res.Equals(Constant.SeatNotFound))
                return new ResponseResult(404, res, null);
            else
                return new ResponseResult(500,null, res);
        }
 
        public async Task<ResponseResult> GetAvailableSeats(int floorId)
        {
            var res= await _unitOfWork.SeatRepository.GetAvailableSeats(floorId);
            if (res != null && res.Count()>0)
                return new ResponseResult(200,res, null);
            else if (res.Count() == 0)
                return new ResponseResult(404, res, "norecords");
            else
                return new ResponseResult(500,null, null);
        }

       
        public async Task<ResponseResult> Allocate(SeatAllocat SeatAllocat)
        {
            var res = await _unitOfWork.SeatRepository.Allocate(SeatAllocat);
            if (res != null && res.Equals(Constant.SeatAllocated))
                return new ResponseResult(200,res, null);
            else if (res != null && res.Equals(Constant.EmployeeExists))
                return new ResponseResult(403, null, res);
            else if (res != null && res.Equals(Constant.SeatTypeMismatch))
                return new ResponseResult(409, null, res);
            else if (res != null && res.Equals(Constant.SeatExists))
                return new ResponseResult(103, null, res);
            else
                return new ResponseResult(500,null, res);
        }

        
        public async Task<ResponseResult> Reallocate(SeatAllocat seatAllocat)
        {
            var res = await _unitOfWork.SeatRepository.Reallocate(seatAllocat);
            if (res != null && res.Equals(Constant.SeatReallocated))
                return new ResponseResult(200,res, null);
            else if (res != null && res.Equals(Constant.EmployeeExists))
                return new ResponseResult(403, null, res);
            else if (res != null && res.Equals(Constant.SeatTypeMismatch))
                return new ResponseResult(409, null, res);
            else if (res != null && res.Equals(Constant.SeatExists))
                return new ResponseResult(403, null, res);
            else
                return new ResponseResult(500,null, res);
        }

        #endregion
    }
}
