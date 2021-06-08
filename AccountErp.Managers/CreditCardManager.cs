using AccountErp.Dtos;
using AccountErp.Dtos.CreditCard;
using AccountErp.Factories;
using AccountErp.Infrastructure.DataLayer;
using AccountErp.Infrastructure.Managers;
using AccountErp.Infrastructure.Repositories;
using AccountErp.Models.CreditCard;
using AccountErp.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountErp.Managers
{
    public class CreditCardManager : ICreditCardManager
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public CreditCardManager(IHttpContextAccessor contextAccessor, 
            ICreditCardRepository creditCardRepository,
            IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _creditCardRepository = creditCardRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task AddAsync(CreditCardAddModel model, string header)
        {
            await _creditCardRepository.AddAsync(CreditCardFactory.Create(model,_userId, header));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(CreditCardEditModel model, string header)
        {
            var creditCard = await _creditCardRepository.GetAsync(model.Id, Convert.ToInt32(header));
            CreditCardFactory.Create(model, creditCard,_userId, header);
            _creditCardRepository.Edit(creditCard);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<CreditCardDetailDto> GetDetailAsync(int id, int header)
        {
            return await _creditCardRepository.GetDetailAsync(id, header);
        }
        public async Task<CreditCardDetailDto> GetForEditAsync(int id, int header)
        {
            return await _creditCardRepository.GetForEditAsync(id, header);
        }

        public async Task<JqDataTableResponse<CreditCardListItemDto>> GetPagedResultAsync(CreditCardJqDataTableRequestModel model, int header)
        {
            return await _creditCardRepository.GetPagedResultAsync(model, header);
        }

        public async Task<bool> IsCreditCardNumberExistsAsync(string creditCardNumber)
        {
            return await _creditCardRepository.IsCreditCardNumberExistsAsync(creditCardNumber);
        }

        public async Task<bool> IsCreditCardNumberExistsForEditAsync(int id, string creditCardNumber)
        {
            return await _creditCardRepository.IsCreditCardNumberExistsForEditAsync(id, creditCardNumber);
        }


        public async Task<IEnumerable<SelectListItemDto>> GetSelectItemsAsync(int header)
        {
            return await _creditCardRepository.GetSelectItemsAsync(header);
        }

        public async Task ToggleStatusAsync(int id, int header)
        {
            await _creditCardRepository.ToggleStatusAsync(id, header);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, int header)
        {
            await _creditCardRepository.DeleteAsync(id, header);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
