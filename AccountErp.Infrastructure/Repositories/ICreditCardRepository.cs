﻿using AccountErp.Dtos;
using AccountErp.Dtos.CreditCard;
using AccountErp.Entities;
using AccountErp.Models.CreditCard;
using AccountErp.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Repositories
{
    public interface ICreditCardRepository
    {
        Task AddAsync(CreditCard entity);

        void Edit(CreditCard entity);

        Task<CreditCard> GetAsync(int id, int header);

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
