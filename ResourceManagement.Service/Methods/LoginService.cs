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
using ResourceManagement.Models;

namespace ResourceManagement.Service.Methods
{
    public class LoginService : ILoginService
    {
        #region Private Variables
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        /// <summary>
        /// LoginService
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public LoginService(ILogger<LoginService> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #endregion

     

        public async Task<bool> ValidateUser(UserModel user)
        {
            bool res = _mapper.Map<bool>(await _unitOfWork.LoginRepository.ValidateUser(user));
            //if (res != null && res.Count() > 0)
            //    return new ResponseResult(200,res, null);
            //if (res.Count() == 0)
            //    return new ResponseResult(403, res, "invaliduser");
            //else
            //    return new ResponseResult(500,null, null);
            return res;
        }
      
        
    }
}
