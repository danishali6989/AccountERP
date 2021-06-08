﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountErp.Api.Helpers;
using AccountErp.Infrastructure.Managers;
using AccountErp.Models.Project;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountErp.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectManager _manager;

        public ProjectController(IProjectManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] ProjectAddModel model)
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
        public async Task<IActionResult> Edit([FromBody] ProjectEditModel model)
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
        public async Task<IActionResult> GetPagedResult(ProjectJqDataTableRequestModel model)
        {
            var pagedResult = await _manager.GetPagedResultAsync(model);
            return Ok(pagedResult);
        }



        [HttpGet]
        [Route("get-select-Project")]
        public async Task<IActionResult> GetSelectItems()
        {
            return Ok(await _manager.GetSelectItemsAsync());
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
          
                await _manager.DeleteAsync(id);
                return Ok();
           
        }

        [HttpPost]
        [Route("get-invoice-byProjectId/{id}")]
        public async Task<IActionResult> GetProjectByInvoiceId(int id)
        {
            var pagedResult = await _manager.GetInvoiceByProjectIdAsync(id);
            return Ok(pagedResult);
        }
        [HttpPost]
        [Route("get-bill-byProjectId/{id}")]
        public async Task<IActionResult> GetProjectByBillId(int id)
        {
            var pagedResult = await _manager.GetBillByProjectIdAsync(id);
            return Ok(pagedResult);
        }
        [HttpPost]
        [Route("get-Project-dashboard/{id}")]
        public async Task<IActionResult> GetProjectDashboard(int id)
        {
            var pagedResult = await _manager.GetDashboardByProjectIdAsync(id);
            return Ok(pagedResult);
        }

        [HttpPost]
        [Route("get-top5-invoice/{id}")]
        public async Task<IActionResult> GetTop5Invoice(int id)
        {
            var pagedResult = await _manager.GetTop5InvoiceAsync(id);
            return Ok(pagedResult);
        }
        [HttpPost]
        [Route("get-top5-bill/{id}")]
        public async Task<IActionResult> GetTop5Bill(int id)
        {
            var pagedResult = await _manager.GetTop5BillAsync(id);
            return Ok(pagedResult);
        }
    }
}