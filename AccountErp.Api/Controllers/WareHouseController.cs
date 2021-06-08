using AccountErp.Api.Helpers;
using AccountErp.Infrastructure.Managers;
using AccountErp.Models.WareHouse;
using AccountErp.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountErp.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    //[Authorize]
    [ApiController]
    public class WareHouseController : ControllerBase
    {
        private readonly IWareHouseManager _manager;

        public WareHouseController(IWareHouseManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] WareHouseAddModel model)
        {
            var header1 = Request.Headers["CompanyTenantId"];
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            try
            {
                await _manager.AddAsync(model, header1.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] WareHouseEditModel model)
        {
            var header1 = Request.Headers["CompanyTenantId"];

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            try 
            {
                await _manager.EditAsync(model, header1.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }


        [HttpGet]
        [Route("get-detail/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var header1 = Request.Headers["CompanyTenantId"];

            var item = await _manager.GetDetailAsync(id,Convert.ToInt32( header1));
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var header1 = Request.Headers["CompanyTenantId"];

            await _manager.DeleteAsync(id, Convert.ToInt32(header1));

            return Ok();
        }

        [HttpPost]
        [Route("paged-result")]
        public async Task<IActionResult> GetPagedResult(WareHouseJqDataTableRequestModel model)
        {
            var header1 = Request.Headers["CompanyTenantId"];

            var pagedResult = await _manager.GetPagedResultAsync(model, Convert.ToInt32(header1));
            return Ok(pagedResult);
        }

        [HttpGet]
        [Route("get-all-active-only")]
        public async Task<IActionResult> GetAllActiveOnly()
        {
            var header1 = Request.Headers["CompanyTenantId"];
            var pagedResult = await _manager.GetAllAsync( Convert.ToInt32(header1), Constants.RecordStatus.Active);

            return Ok(pagedResult);
        }
    }
}
