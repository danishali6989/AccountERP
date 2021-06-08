using AccountErp.Dtos.CreditMemo;
using AccountErp.Models.CreditMemo;
using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Managers
{
   public  interface ICreditMemoManager
    {
        Task AddAsync(CreditMemoAddModel model, string header);

        Task<JqDataTableResponse<CreditMemoListItemDto>> GetPagedResultAsync(CreditMemoJqDataTableRequestModel model, int header);

        Task<CreditMemoDetailDto> GetDetailAsync(int id, int header);
        Task EditAsync(CreditMemoEditModel model, string header);
        Task DeleteAsync(int id, int header);
    }
}
