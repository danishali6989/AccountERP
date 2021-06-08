using AccountErp.Dtos;
using AccountErp.Dtos.Bill;
using AccountErp.Dtos.Invoice;
using AccountErp.Dtos.Project;
using AccountErp.Factories;
using AccountErp.Infrastructure.DataLayer;
using AccountErp.Infrastructure.Managers;
using AccountErp.Infrastructure.Repositories;
using AccountErp.Models.Project;
using AccountErp.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace AccountErp.Managers
{
    public class ProjectManager : IProjectManager
    {
        private readonly IProjectRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public ProjectManager(IHttpContextAccessor contextAccessor,
            IProjectRepository repository,
            IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(ProjectAddModel model)
        {
            await _repository.AddAsync(ProjectFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(ProjectEditModel model)
        {
            var item = await _repository.GetAsync(model.Id);
            ProjectFactory.Create(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ProjectDetailDto> GetDetailAsync(int id)
        {
            return await _repository.GetDetailAsync(id);
        }

        public async Task<JqDataTableResponse<ProjectListItemDto>> GetPagedResultAsync(ProjectJqDataTableRequestModel model)
        {
            return await _repository.GetPagedResultAsync(model);
        }

        public async Task<IEnumerable<SelectListItemDto>> GetSelectItemsAsync()
        {
            return await _repository.GetSelectItemsAsync();
        }


        public async Task<ProjectDetailForEditDto> GetForEditAsync(int id)
        {
            return await _repository.GetForEditAsync(id);
        }

        public async Task<List<InvoiceListItemDto>> GetInvoiceByProjectIdAsync(int projectId)
        {
            return await _repository.GetInvoiceByProjectIdAsync(projectId);
        }

        public async Task<List<BillListItemDto>> GetBillByProjectIdAsync(int projectId)
        {
            return await _repository.GetBillByProjectIdAsync(projectId);
        }

        public async Task<ProjectDashboardDto> GetDashboardByProjectIdAsync(int projectId)
        {
            ProjectDashboardDto projectDashboardDto = new ProjectDashboardDto();
            var invList = await _repository.GetInvoiceByProjectIdAsync(projectId);
            var billList = await _repository.GetBillByProjectIdAsync(projectId);

            projectDashboardDto.Income = invList.Sum(x => x.SubTotal) ?? 0;
            projectDashboardDto.Cost = billList.Sum(x => x.SubTotal) ?? 0;
            projectDashboardDto.Profit = projectDashboardDto.Income - projectDashboardDto.Cost;
            return projectDashboardDto;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<InvoiceListItemDto>> GetTop5InvoiceAsync(int projectId)
        {
            return await _repository.GetTop5InvoiceAsync(projectId);
        }
        public async Task<List<BillListItemDto>> GetTop5BillAsync(int projectId)
        {
            return await _repository.GetTop5BillAsync(projectId);
        }
    }
}
