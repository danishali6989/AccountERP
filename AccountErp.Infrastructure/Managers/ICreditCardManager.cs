using AccountErp.Dtos;
using AccountErp.Dtos.CreditCard;
using AccountErp.Models.CreditCard;
using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Managers
{
    public interface ICreditCardManager
    {
        Task AddAsync(CreditCardAddModel model, string header);
        Task EditAsync(CreditCardEditModel model, string header);

        Task<CreditCardDetailDto> GetDetailAsync(int id, int header);
        Task<CreditCardDetailDto> GetForEditAsync(int id, int header);

        Task<JqDataTableResponse<CreditCardListItemDto>> GetPagedResultAsync(CreditCardJqDataTableRequestModel model, int header);

        Task<bool> IsCreditCardNumberExistsAsync(string creditCardNumber);
        Task<bool> IsCreditCardNumberExistsForEditAsync(int id, string creditCardNumber);

        Task<IEnumerable<SelectListItemDto>> GetSelectItemsAsync(int header);

        Task ToggleStatusAsync(int id, int header);
        Task DeleteAsync(int id, int header);
    }
}
