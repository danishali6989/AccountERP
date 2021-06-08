using AccountErp.Api.Helpers;
using AccountErp.Infrastructure.Managers;
using AccountErp.Models.CreditCard;
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
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardManager _creditCardManager;

        public CreditCardController(ICreditCardManager creditCardManager)
        {
            _creditCardManager = creditCardManager;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody]CreditCardAddModel model)
        {
            var header = Request.Headers["CompanyTenantId"];

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            if (await _creditCardManager.IsCreditCardNumberExistsAsync(model.CreditCardNumber))
            {
                return BadRequest("Credit card number already exists");
            }
            try
            {
                await _creditCardManager.AddAsync(model, header.ToString());
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
            var header = Request.Headers["CompanyTenantId"];

            var creditCard = await _creditCardManager.GetDetailAsync(id, Convert.ToInt32(header));
            if (creditCard == null)
            {
                return NotFound();
            }
            return Ok(creditCard);
        }

        [HttpGet]
        [Route("get-for-edit/{id}")]
        public async Task<IActionResult> GetForEdit(int id)
        {
            var header = Request.Headers["CompanyTenantId"];

            var creditCard = await _creditCardManager.GetForEditAsync(id, Convert.ToInt32(header));
            if (creditCard == null)
            {
                return NotFound();
            }
            return Ok(creditCard);
        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody]CreditCardEditModel model)
        {
            var header = Request.Headers["CompanyTenantId"];

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            if (await _creditCardManager.IsCreditCardNumberExistsForEditAsync(model.Id, model.CreditCardNumber))
            {
                return BadRequest("Credit card number already exists");
            }
            try
            {
                await _creditCardManager.EditAsync(model, header.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPost]
        [Route("paged-result")]
        public async Task<IActionResult> GetPagedResult(CreditCardJqDataTableRequestModel model)
        {
            var header = Request.Headers["CompanyTenantId"];
            var pagedResult = await _creditCardManager.GetPagedResultAsync(model, Convert.ToInt32(header));
            return Ok(pagedResult);
        }

        [HttpGet]
        [Route("get-select-items")]
        public async Task<IActionResult> GetSelectItems()
        {
            var header = Request.Headers["CompanyTenantId"];

            return Ok(await _creditCardManager.GetSelectItemsAsync(Convert.ToInt32(header)));
        }

        [HttpPost]
        [Route("toggle-status/{id}")]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var header = Request.Headers["CompanyTenantId"];

            await _creditCardManager.ToggleStatusAsync(id, Convert.ToInt32(header));

            return Ok();
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var header = Request.Headers["CompanyTenantId"];

            await _creditCardManager.DeleteAsync(id, Convert.ToInt32(header));

            return Ok();
        }
    }
}