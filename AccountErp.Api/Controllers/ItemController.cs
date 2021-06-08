using AccountErp.Api.Helpers;
using AccountErp.Infrastructure.Managers;
using AccountErp.Models.Item;
using AccountErp.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AccountErp.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
   // [Authorize]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemManager _manager;

        public ItemController(IItemManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] ItemAddModel model)
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
        public async Task<IActionResult> Edit([FromBody] ItemEditModel model)
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

            var item = await _manager.GetDetailAsync(id, Convert.ToInt32(header1));
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet]
        [Route("get-for-edit/{id}")]
        public async Task<IActionResult> GetForEdit(int id)
        {
            var header1 = Request.Headers["CompanyTenantId"];

            var item = await _manager.GetForEditAsync(id, Convert.ToInt32(header1));
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        [Route("paged-result")]
        public async Task<IActionResult> GetPagedResult(ItemJqDataTableRequestModel model)
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

            return Ok(await _manager.GetAllAsync(Convert.ToInt32(header1), Constants.RecordStatus.Active));
        }




        [HttpGet]
        [Route("get-all-forSales")]
        public async Task<IActionResult> GetAllForSales()
        {
            var header1 = Request.Headers["CompanyTenantId"];

            return Ok(await _manager.GetAllForSalesAsync(Convert.ToInt32(header1), Constants.RecordStatus.Active));
        }


        [HttpGet]
        [Route("get-all-forExpense")]
        public async Task<IActionResult> GetAllForExpense()
        {
            var header1 = Request.Headers["CompanyTenantId"];

            return Ok(await _manager.GetAllForExpenseAsync(Convert.ToInt32(header1), Constants.RecordStatus.Active));
        }

        [HttpGet]
        [Route("get-select-items")]
        public async Task<IActionResult> GetSelectItems()
        {
            var header1 = Request.Headers["CompanyTenantId"];

            return Ok(await _manager.GetSelectItemsAsync(Convert.ToInt32(header1)));
        }

        [HttpPost]
        [Route("toggle-status/{id}")]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var header1 = Request.Headers["CompanyTenantId"];

            await _manager.ToggleStatusAsync(id, Convert.ToInt32(header1));
            return Ok();
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var header1 = Request.Headers["CompanyTenantId"];

            if (_manager.checkItemAvailable(id))
            {
                await _manager.DeleteAsync(id, Convert.ToInt32(header1));
                return Ok();
            }
            else
            {
                return BadRequest("This Item & Services Is Already Exists.");
            }
        }

    }
}