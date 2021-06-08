using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountErp.Api.Helpers;
using AccountErp.Infrastructure.Managers;
using AccountErp.Models.Product;
using AccountErp.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountErp.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _manager;

        public ProductController(IProductManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] ProductAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
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
        public async Task<IActionResult> Edit([FromBody] ProductEditModel model)
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
        [Route("get-detail/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var item = await _manager.GetDetailAsync(id);
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
            var item = await _manager.GetForEditAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        [Route("paged-result")]
        public async Task<IActionResult> GetPagedResult(ProductJqDataTableRequestModel model)
        {
            var pagedResult = await _manager.GetPagedResultAsync(model);
            return Ok(pagedResult);
        }


        [HttpPost]
        [Route("Get-Inventory-paged-result")]
        public async Task<IActionResult> GetInventoryPagedResultAsync(ProductInventoryJqDataTableRequestModel model)
        {
            var pagedResult = await _manager.GetInventoryPagedResultAsync(model);
            return Ok(pagedResult);
        }

        [HttpGet]
        [Route("get-all-active-only")]
        public async Task<IActionResult> GetAllActiveOnly()
        {
            return Ok(await _manager.GetAllAsync(Constants.RecordStatus.Active));
        }

        [HttpGet]
        [Route("get-select-items")]
        public async Task<IActionResult> GetSelectItems()
        {
            return Ok(await _manager.GetSelectItemsAsync());
        }

        [HttpPost]
        [Route("toggle-status/{id}")]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            await _manager.ToggleStatusAsync(id);
            return Ok();
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_manager.checkItemAvailable(id))
            {
                await _manager.DeleteAsync(id);
                return Ok();
            }
            else
            {
                return BadRequest("This Item & Services Is Already Exists.");
            }
        }

        [HttpPost]
        [Route("transferWarehouse")]
        public async Task<IActionResult> TranserWareHouse(int id,int wareHouseId)
        {
            await _manager.TransferWareHouse(id, wareHouseId);
            return Ok();
        }

    }
}