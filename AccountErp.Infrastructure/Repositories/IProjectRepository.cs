using AccountErp.Dtos;
using AccountErp.Dtos.Bill;
using AccountErp.Dtos.Invoice;
using AccountErp.Dtos.Project;
using AccountErp.Entities;
using AccountErp.Models.Project;
using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Repositories
{
    public interface IProjectRepository
    {
        Task AddAsync(Project entity);
        Task AddProjectTransactionAsync(ProjectTransaction entity);
        void Edit(Project entity);

        Task<Project> GetAsync(int id);
        Task<Project> GetAsyncByCustId(int custId);

        Task<IEnumerable<Project>> GetAsync(List<int> itemIds);

        Task<ProjectDetailDto> GetDetailAsync(int id);


        Task<ProjectDetailForEditDto> GetForEditAsync(int id);

        Task<JqDataTableResponse<ProjectListItemDto>> GetPagedResultAsync(ProjectJqDataTableRequestModel model);

        Task<IEnumerable<SelectListItemDto>> GetSelectItemsAsync();

        Task DeleteAsync(int id);
        Task<List<InvoiceListItemDto>> GetInvoiceByProjectIdAsync(int projectId);
        Task<List<BillListItemDto>> GetBillByProjectIdAsync(int projectId);
        Task<List<InvoiceListItemDto>> GetTop5InvoiceAsync(int projectId);
        Task<List<BillListItemDto>> GetTop5BillAsync(int projectId);
    }
}
