using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Api.Helpers;
using UserManagement.Infrastructure.Managers;
using UserManagement.Models.UserLogin;
using UserManagement.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserManager _manager;
        private readonly IHostingEnvironment _environment;

        public UserController(IConfiguration configuration, IUserManager manager,
            IHostingEnvironment environment)
        {
            _configuration = configuration;
            _manager = manager;
            _environment = environment;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] UserLoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            if(await _manager.CheckUser(model.UserName) != null)
            {
                return BadRequest("UserName Already SS Exist");
            }

            try
            {
                await _manager.AddAsync(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] UserLoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            try
            {
                await _manager.EditAsync(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("get-detail/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var data = await _manager.GetDetailAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        [Route("paged-result")]
        public async Task<IActionResult> PagedResult(JqDataTableRequest model)
        {
            return Ok(await _manager.GetPagedResultAsync(model));
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manager.DeleteAsync(id);

            return Ok();
        }
        /*[HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            var data = await _manager.CheckUser(model.UserName);
            if(data != null)
            {
                if (UserManagement.Utilities.Utility.Decrypt(model.Password,data.Password)==false)
                {
                    return BadRequest("Invalid Password");
                }
                else
                {
                    await _manager.LoginAddAsync(data);

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Jwt:secret"));
                    var tokenDescription = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[]
                        { new Claim("id", data.Id.ToString()) ,
                            new Claim("Name", data.UserName.ToString()),
                             new Claim("RoleId", data.RoleId.ToString()),
                             new Claim("RoleName", data.RoleName.ToString()),
                             new Claim("CompanyTenantId", data.CompanyTenantId.ToString())
                        }
                        ),
                        Audience = _configuration.GetValue<string>("Jwt:Audience"),
                        Issuer = _configuration.GetValue<string>("Jwt:Issuer"),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescription);

                    return Ok(tokenHandler.WriteToken(token));
                }
            }
            else
            {
                return BadRequest("Invalid UserName");
            }
           
            
        }

        [HttpPost]
        [Route("agent-paged-result")]
        public async Task<IActionResult> AgentPagedResult(JqDataTableRequest model)
        {
            return Ok(await _manager.GetAgentPagedResultAsync(model));
        }

        [HttpPost]
        [Route("logout/{id}")]
        public async Task<IActionResult> LogOut(int id)
        {
            await _manager.LogOut(id);
            return Ok();
        }

        [HttpPost]
        [Route("onlineAgent-paged-result")]
        public async Task<IActionResult> OnlineAgentPagedResult(JqDataTableRequest model)
        {
            return Ok(await _manager.GetOnlineAgentPagedResultAsync(model));
        }

        [HttpPost]
        [Route("getOnly-Online-paged-result")]
        public async Task<IActionResult> OnlyneAgentPagedResult(JqDataTableRequest model)
        {
            return Ok(await _manager.GetOnlyOnlineAgentPagedResultAsync(model));
        }*/
    }
}