﻿using AccountErp.Dtos;
using AccountErp.Dtos.Product;
using AccountErp.Factories;
using AccountErp.Infrastructure.DataLayer;
using AccountErp.Infrastructure.Managers;
using AccountErp.Infrastructure.Repositories;
using AccountErp.Models.Product;
using AccountErp.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountErp.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public ProductManager(IHttpContextAccessor contextAccessor,
            IProductRepository repository,
            IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(ProductAddModel model)
        {
            await _repository.AddAsync(ProductFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(ProductEditModel model)
        {
            var item = await _repository.GetAsync(model.Id);
            ProductFactory.Create(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ProductDetailDto> GetDetailAsync(int id)
        {
            var data = await _repository.GetDetailAsync(id);
            var invSum = _repository.InvoiceProductCount(id, null, null);
            var billSum = _repository.BillProductCount(id, null, null);
            var creditSum = _repository.CreditMemoProductCount(id, null, null);
            data.AvailableStock = data.InitialStock + billSum + creditSum - invSum ?? 0;
            return data;
        }


        public async Task<JqDataTableResponse<ProductListItemDto>> GetPagedResultAsync(ProductJqDataTableRequestModel model)
        {
            return await _repository.GetPagedResultAsync(model);
        }


        public async Task<JqDataTableResponse<ProductListItemDto>> GetInventoryPagedResultAsync(ProductInventoryJqDataTableRequestModel model)
        {

            var response = await _repository.GetInventoryPagedResultAsync(model);
            foreach (var item in response.Data)
            {
                var invSum = _repository.InvoiceProductCount(item.Id, model.StartDate, model.EndDate);
                var billSum = _repository.BillProductCount(item.Id, model.StartDate, model.EndDate);
                var creditSum = _repository.CreditMemoProductCount(item.Id, model.StartDate, model.EndDate);
                //  var invCountByDate = _repository.InvoiceProductCountWithDate(item.Id, model.StartDate, model.EndDate);
                var count = item.InitialStock + billSum + creditSum - invSum;
                item.InitialStock = count;
            }
            return response;
        }


        public async Task<IEnumerable<SelectListItemDto>> GetSelectItemsAsync()
        {
            return await _repository.GetSelectItemsAsync();
        }

        public async Task<IEnumerable<ProductDetailDto>> GetAllAsync(Constants.RecordStatus? status = null)
        {
            var response = await _repository.GetAllAsync(status);
            foreach (var item in response)
            {
                var invSum = _repository.InvoiceProductCount(item.Id, null, null);
                var billSum = _repository.BillProductCount(item.Id, null, null);
                var creditSum = _repository.CreditMemoProductCount(item.Id, null, null);
                var count = item.InitialStock + billSum + creditSum - invSum;
                item.AvailableStock = count ?? 0;
            }
            return response;
        }

        public async Task<ProductDetailForEditDto> GetForEditAsync(int id)
        {
            return await _repository.GetForEditAsync(id);
        }

        public async Task ToggleStatusAsync(int id)
        {
            await _repository.ToggleStatusAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public bool checkItemAvailable(int id)
        {
            return _repository.checkItemAvailable(id);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TransferWareHouse(int id, int wareHouseId)
        {
            await _repository.TransferWareHouse(id,wareHouseId);
            await _unitOfWork.SaveChangesAsync();
        }
        //public async Task<IEnumerable<ProductDetailDto>> GetAllForSalesAsync(Constants.RecordStatus? status = null)
        //{
        //    return await _repository.GetAllForSalesAsync(status);
        //}

        //public async Task<IEnumerable<ItemDetailDto>> GetAllForExpenseAsync(Constants.RecordStatus? status = null)
        //{
        //    return await _repository.GetAllForExpenseAsync(status);
        //}



    }
}
