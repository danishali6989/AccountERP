using AccountErp.Dtos.WareHouse;
using AccountErp.Factories;
using AccountErp.Infrastructure.DataLayer;
using AccountErp.Infrastructure.Managers;
using AccountErp.Infrastructure.Repositories;
using AccountErp.Models.WareHouse;
using AccountErp.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountErp.Managers
{
   public class WareHouseManager : IWareHouseManager
    {
        private readonly IWareHouseRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public WareHouseManager(IHttpContextAccessor contextAccessor,
            IWareHouseRepository repository,
            IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(WareHouseAddModel model,string header1)
        {
            await _repository.AddAsync(WareHouseFactory.Create(model, _userId, header1));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(WareHouseEditModel model, string header1)
        {
            var warehouse = await _repository.GetAsync(model.Id,Convert.ToInt32 (header1));
            WareHouseFactory.Create(model, warehouse, _userId, header1);
            _repository.Edit(warehouse);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<WareHouseDetailsDto> GetDetailAsync(int id, int header1)
        {
            return await _repository.GetDetailAsync(id, header1);
        }

        public async Task DeleteAsync(int id, int header1)
        {
            await _repository.DeleteAsync(id,header1);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<JqDataTableResponse<WareHouseDetailsListDto>> GetPagedResultAsync(WareHouseJqDataTableRequestModel model, int header1)
        {
            return await _repository.GetPagedResultAsync(model, header1);
        }

        public async Task<IEnumerable<WareHouseDetailsDto>> GetAllAsync(int header1,Constants.RecordStatus? status = null)
        {
            return await _repository.GetAllAsync(header1, status);
        }
    }
}
