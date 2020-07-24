using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ResourceManagement.Models;
using ResourceManagement.Service.Contract;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using ResourceManagement.ResponseResult;

namespace ResourceManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Private Variables
        private IConfiguration _config;
        private readonly ILogger _logger;
        private readonly ILoginService _loginService;
        #endregion
        public LoginController(ILogger<LoginController> logger, ILoginService loginService, IConfiguration config)
        {
            _logger = logger;
            _loginService = loginService;
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserModel login)
        {
            IActionResult response = Unauthorized();
            try
            {
                
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);
                    bool result = await _loginService.ValidateUser(login);
                    if(result == false)
                    {
                        return BadRequest(new { message = "Username or Password is incorrect!" });
                    }
               
                if (result != false)
                    {
                        var tokenString = GenerateJSONWebToken(login);
                        response = Ok(new { token = tokenString });
                    }
                //return StatusCode(result.StatusCode, result);

                return response;
              
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
           
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Iat, userInfo.Password),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
