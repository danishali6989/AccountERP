using AccountErp.Dtos;
using AccountErp.Dtos.Invoice;
using AccountErp.Entities;
using AccountErp.Models.Invoice;
using AccountErp.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Repositories
{
    public interface IInvoiceRepository
    {
        Task AddAsync(Invoice entity);

        void Edit(Invoice entity);

        Task<Invoice> GetAsync(int id, int header);

        Task<InvoiceDetailDto> GetDetailAsync(int id, int header);

        Task<InvoiceDetailDto> GetDetailAsyncforpyment(int id, int header);


        Task<InvoiceDetailForEditDto> GetForEditAsync(int id, int header);

        Task<JqDataTableResponse<InvoiceListItemDto>> GetPagedResultAsync(InvoiceJqDataTableRequestModel model, int header);

        Task<JqDataTableResponse<InvoiceListItemDto>> GetTopFiveInvoicesAsync(InvoiceJqDataTableRequestModel model, int header);

        

        Task<List<InvoiceListItemDto>> GetRecentAsync(int header);

        Task<InvoiceSummaryDto> GetSummaryAsunc(int id);

        Task UpdateStatusAsync(int id, Constants.InvoiceStatus status);

        Task DeleteAsync(int id, int header);

        Task<int> getCount(int header);
        Task<List<InvoiceListItemDto>> GetAllUnpaidInvoiceAsync(int header);
        Task<List<InvoiceListTopTenDto>> GetTopTenInvoicesAsync(int header);
        Task<IEnumerable<SelectListItemDto>> GetSelectInoviceAsync(int header);
    }
}
