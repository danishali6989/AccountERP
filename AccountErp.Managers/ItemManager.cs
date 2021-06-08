using AccountErp.Dtos;
using AccountErp.Dtos.Item;
using AccountErp.Factories;
using AccountErp.Infrastructure.DataLayer;
using AccountErp.Infrastructure.Managers;
using AccountErp.Infrastructure.Repositories;
using AccountErp.Models.Item;
using AccountErp.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountErp.Managers
{
    public class ItemManager : IItemManager
    {
        private readonly IItemRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public ItemManager(IHttpContextAccessor contextAccessor,
            IItemRepository repository,
            IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(ItemAddModel model, string header1)
        {
            await _repository.AddAsync(ItemFactory.Create(model, _userId, header1));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(ItemEditModel model, string header1)
        {
            var item = await _repository.GetAsync(model.Id, Convert.ToInt32(header1));
            ItemFactory.Edit(model, item, _userId, header1);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ItemDetailDto> GetDetailAsync(int id, int header1)
        {
            return await _repository.GetDetailAsync(id, header1);
        }

        public async Task<JqDataTableResponse<ItemListItemDto>> GetPagedResultAsync(ItemJqDataTableRequestModel model, int header1)
        {
            return await _repository.GetPagedResultAsync(model, header1);
        }

        public async Task<IEnumerable<SelectListItemDto>> GetSelectItemsAsync(int header1)
        {
            return await _repository.GetSelectItemsAsync(header1);
        }

        public async Task<IEnumerable<ItemDetailDto>> GetAllAsync(int header1, Constants.RecordStatus? status = null)
        {
            return await _repository.GetAllAsync(header1,status);
        }

        public async Task<ItemDetailForEditDto> GetForEditAsync(int id, int header1)
        {
            return await _repository.GetForEditAsync(id, header1);
        }

        public async Task ToggleStatusAsync(int id, int header1)
        {
            await _repository.ToggleStatusAsync(id, header1);
            await _unitOfWork.SaveChangesAsync();
        }

        public bool checkItemAvailable(int id)
        {
           return _repository.checkItemAvailable(id);
        }

        public async Task DeleteAsync(int id, int header1)
        {
            await _repository.DeleteAsync(id, header1);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemDetailDto>> GetAllForSalesAsync(int header1, Constants.RecordStatus? status = null)
        {
            return await _repository.GetAllForSalesAsync(header1, status);
        }

        public async Task<IEnumerable<ItemDetailDto>> GetAllForExpenseAsync(int header1, Constants.RecordStatus? status = null)
        {
            return await _repository.GetAllForExpenseAsync(header1, status);
        }


        
    }
}
