using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResourceManagement.DTO.Model;
using ResourceManagement.Models.Model;
using ResourceManagement.Repository.Contract;
using ResourceManagement.Service.Contract;

namespace ResourceManagement.Service.Methods
{
    public class FloorService : IFloorService
    {
        #region Private Variables
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor

        /// <summary>
        /// FloorService
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public FloorService(ILogger<FloorService> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods
     
        public async Task<ResponseResult> GetAllFloors()
        {            
            var res=_mapper.Map<IEnumerable<FloorDTO>>(await _unitOfWork.FloorRepository.GetAllFloors());
            if (res != null && res.Count() > 0)
                return new ResponseResult(200,res, null);
            else
                return new ResponseResult(400,null, null);
        }

        #endregion
    }
}
