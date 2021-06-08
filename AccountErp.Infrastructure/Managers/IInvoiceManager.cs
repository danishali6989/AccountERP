using AccountErp.Dtos;
using AccountErp.Dtos.Invoice;
using AccountErp.Models.Invoice;
using AccountErp.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Managers
{
    public interface IInvoiceManager
    {
        Task AddAsync(InvoiceAddModel model, string header);

        Task EditAsync(InvoiceEditModel model, string header);

        Task<InvoiceDetailDto> GetDetailAsync(int id, int header);

        Task<InvoiceDetailDto> GetDetailAsyncforpyment(int id, int header);


        Task<InvoiceDetailForEditDto> GetForEditAsync(int id, int header);

        Task<JqDataTableResponse<InvoiceListItemDto>> GetPagedResultAsync(InvoiceJqDataTableRequestModel model, int header);


        Task<JqDataTableResponse<InvoiceListItemDto>> GetTopFiveInvoicesAsync(InvoiceJqDataTableRequestModel model, int header);
        

        Task<List<InvoiceListItemDto>> GetRecentAsync(int header);

        Task<InvoiceSummaryDto> GetSummaryAsunc(int id, int header);

        Task DeleteAsync(int id, int header);

        Task<int> GetInvoiceNumber(int header);
        Task<List<InvoiceListItemDto>> GetAllUnpaidInvoiceAsync(int header);
        Task<InvoiceCountDto> GetTopTenInvoicesAsync(int header);
        Task<IEnumerable<SelectListItemDto>> GetSelectInoviceAsync(int header);
    }
}
