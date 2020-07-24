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
    public class EmployeeService : IEmployeeService
    {
        #region Private Variables
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        /// <summary>
        /// EmployeeService
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public EmployeeService(ILogger<EmployeeService> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        #endregion

        #region Methods
 


        public async Task<ResponseResult> GetAllEmployeeDetails()
        {
            var res = _mapper.Map<IEnumerable<EmployeeDetailDTO>>(await _unitOfWork.EmployeeRepository.GetAllEmployeeDetails());
            if (res != null && res.Count() > 0)
                return new ResponseResult(200, res, null);
            else if (res.Count() == 0)
                return new ResponseResult(404, res, "norecords");
            else
                return new ResponseResult(500, null, null);

        }



        public async Task<ResponseResult> SearchAllotedEmployees(string searchkey, bool? isallocated)
        {
            var res = _mapper.Map<IEnumerable<EmployeeDetailDTO>>(await _unitOfWork.EmployeeRepository.SearchAllotedEmployees(searchkey,  isallocated));
                if (res != null && res.Count() > 0)
                    return new ResponseResult(200, res, null);
                else if (res.Count() == 0)
                    return new ResponseResult(404, res, "norecords");
                else
                    return new ResponseResult(500, null, null);
        }

        #endregion
    }
}
