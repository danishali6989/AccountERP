using AccountErp.Dtos.CreditMemo;
using AccountErp.Entities;
using AccountErp.Models.CreditMemo;
using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Repositories
{
  public  interface ICreditMemoRepository
    {
        Task AddAsync(CreditMemo entity);
        Task<int> getCount();
        void Edit(CreditMemo entity);

        Task<CreditMemo> GetAsync(int id, int header);


        Task<JqDataTableResponse<CreditMemoListItemDto>> GetPagedResultAsync(CreditMemoJqDataTableRequestModel model, int header);
        Task<CreditMemoDetailDto> GetDetailAsync(int id, int header);

        Task<CreditMemoDetailDto> GetCreaditMemoforInvoice(int id);
        Task DeleteAsync(int id, int header);


        //  Task<CreditMemo> GetAsync(int id);

    }
}
