using AccountErp.Api.Helpers;
using AccountErp.Infrastructure.Managers;
using AccountErp.Models.Invoice;
using AccountErp.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace AccountErp.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
   // [Authorize]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceManager _invoiceManager;
        private readonly IHostingEnvironment _environment;
        private readonly IEmailManager _emailManager;
        public InvoiceController(IInvoiceManager invoiceManager,
            IHostingEnvironment environment, IEmailManager emailManager)
        {
            _invoiceManager = invoiceManager;
            _environment = environment;
            _emailManager = emailManager;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody]InvoiceAddModel model)
        {
            var header = Request.Headers["CompanyTenantId"];

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            if (!EnumerableExtensions.Any(model.Items))
            {
                return BadRequest("Please select items/services to continue");
            }

            try
            {
                await _invoiceManager.AddAsync(model, header.ToString());
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
            var header = Request.Headers["CompanyTenantId"];

            var invoice = await _invoiceManager.GetDetailAsync(id, Convert.ToInt32(header));

            if (invoice == null)
            {
                return NotFound();
            }

            if (invoice.Attachments == null)
            {
                return Ok(invoice);
            }

            invoice.Attachments = invoice.Attachments.ToList();

            foreach (var attachment in invoice.Attachments)
            {
                attachment.FileUrl = Utility.GetTempFileUrl(Request.GetBaseUrl(), attachment.FileName);
            }

            return Ok(invoice);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("get-details/{id}")]
        public async Task<IActionResult> GetDetailAsyncforpyment(int id)
        {
            var header = Request.Headers["CompanyTenantId"];

            var invoice = await _invoiceManager.GetDetailAsyncforpyment(id, Convert.ToInt32(header));

            if (invoice == null)
            {
                return NotFound();
            }

            if (invoice.Attachments == null)
            {
                return Ok(invoice);
            }

            invoice.Attachments = invoice.Attachments.ToList();

            foreach (var attachment in invoice.Attachments)
            {
                attachment.FileUrl = Utility.GetTempFileUrl(Request.GetBaseUrl(), attachment.FileName);
            }

            return Ok(invoice);
        }

        [HttpGet]
        [Route("get-for-edit/{id}")]
        public async Task<IActionResult> GetForEdit(int id)
        {
            var header = Request.Headers["CompanyTenantId"];

            var invoice = await _invoiceManager.GetForEditAsync(id, Convert.ToInt32(header));
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody]InvoiceEditModel model)
        {
            var header = Request.Headers["CompanyTenantId"];

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }

            if (!EnumerableExtensions.Any(model.Items))
            {
                return BadRequest("Please select items/services to continue");
            }

            try
            {
                await _invoiceManager.EditAsync(model, header.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPost]
        [Route("paged-result")]
        public async Task<IActionResult> GetPagedResult(InvoiceJqDataTableRequestModel model)
        {
            var header = Request.Headers["CompanyTenantId"];

            var pagedResult = await _invoiceManager.GetPagedResultAsync(model, Convert.ToInt32(header));

            return Ok(pagedResult);
        }

        [HttpPost]
        [Route("getTopFiveInvoice")]
        public async Task<IActionResult> GetTopFiveInvoices(InvoiceJqDataTableRequestModel model)
        {
            var header = Request.Headers["CompanyTenantId"];

            var pagedResult = await _invoiceManager.GetTopFiveInvoicesAsync(model, Convert.ToInt32(header));

            return Ok(pagedResult);
        }
        



        [HttpGet]
        [Route("get-recent")]
        public async Task<IActionResult> GetRecent()
        {
            var header = Request.Headers["CompanyTenantId"];

            var pagedResult = await _invoiceManager.GetRecentAsync(Convert.ToInt32(header));
            return Ok(pagedResult);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var header = Request.Headers["CompanyTenantId"];

            await _invoiceManager.DeleteAsync(id, Convert.ToInt32(header));

            return Ok();
        }

        [HttpPost]
        [Route("upload-attachment")]
        public async Task<IActionResult> UploadAttachment([FromForm]IFormFile file)
        {
            var header = Request.Headers["CompanyTenantId"];

            var dirPath = Utility.GetTempFolder(_environment.WebRootPath);

            var fileName = Utility.GetUniqueFileName(file.FileName);

            using (var fileStream = new FileStream(dirPath + fileName, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Ok(new
            {
                fileName,
                fileUrl = Utility.GetTempFileUrl(Request.GetBaseUrl(), fileName)
            });
        }

        [HttpGet]
        [Route("get-summary/{id}")]
        public async Task<IActionResult> GetSummary(int id)
        {
            var header = Request.Headers["CompanyTenantId"];

            return Ok(await _invoiceManager.GetSummaryAsunc(id, Convert.ToInt32(header)));
        }
        
        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendInvoice(InvoiceSendModel model)
        {
            var header = Request.Headers["CompanyTenantId"];

            var invoice = await _invoiceManager.GetDetailAsync(model.Id, Convert.ToInt32(header));
            if (invoice.Customer.Email == null)
            {
                BadRequest("Customer doesn't have email address");
            }

            var dirPath = Utility.GetInvoiceFolder(_environment.WebRootPath);
            var completePath = dirPath + invoice.Id + "_"  + ".pdf";
            if (!System.IO.File.Exists(completePath))
            {
                var renderer = new IronPdf.HtmlToPdf();
                renderer.RenderHtmlAsPdf(model.Html).SaveAs(completePath);
            }
            await _emailManager.SendInvoiceAsync(invoice.Customer.Email, completePath);
            return Ok();
        }

        [HttpGet]
        [Route("get-InvoiceNumber")]
        public async Task<IActionResult> GetInvoiceNumber()
        {
            var header = Request.Headers["CompanyTenantId"];

            return Ok(await _invoiceManager.GetInvoiceNumber(Convert.ToInt32(header)));
        }

        [HttpGet]
        [Route("get-AllUnPaid")]
        public async Task<IActionResult> GetAllUnpaid()
        {
            var header = Request.Headers["CompanyTenantId"];

            var pagedResult = await _invoiceManager.GetAllUnpaidInvoiceAsync(Convert.ToInt32(header));
            return Ok(pagedResult);
        }

        [HttpGet]
        [Route("getTopTenInvoice")]
        public async Task<IActionResult> GetTopTenInvoices()
        {
            var header = Request.Headers["CompanyTenantId"];

            var pagedResult = await _invoiceManager.GetTopTenInvoicesAsync(Convert.ToInt32(header));

            return Ok(pagedResult);
        }


        [HttpGet]
        [Route("getProductInvoice")]
        public async Task<IActionResult> GetSelectInoviceAsync()
        {
            var header = Request.Headers["CompanyTenantId"];

            return Ok(await _invoiceManager.GetSelectInoviceAsync(Convert.ToInt32(header)));
        }
    }
}