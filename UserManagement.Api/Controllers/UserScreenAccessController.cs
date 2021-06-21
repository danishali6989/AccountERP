using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Infrastructure.Managers;
using UserManagement.Models.UserAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserScreenAccessController : ControllerBase
    {
        private readonly IUserAccessMAnager _manager;
        private readonly IHostingEnvironment _environment;

        public UserScreenAccessController(IUserAccessMAnager manager,
            IHostingEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }


        [HttpPost]
        [Route("AddScreenAccess")]
        public async Task<IActionResult> AddQualifyAnswer(ScreenAccessModel model)
        {
            try
            {
                await _manager.AddUserScreenAccessAsync(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }


        [HttpGet]
        [Route("getScreenAccessByUserRoleIdId/{id}")]
        public async Task<IActionResult> GetQualifyAnser(int id)
        {
            return Ok(await _manager.GetUserScreenAccessById(id));
        }
        [HttpGet]
        [Route("getAllScreens")]
        public async Task<IActionResult> GetAllScreenDetail()
        {
            return Ok(await _manager.GetAllScreenDetail());
        }
    }
}
