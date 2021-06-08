using AccountErp.Dtos.WareHouse;
using AccountErp.Entities;
using AccountErp.Models.WareHouse;
using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Managers
{
  public  interface IWareHouseManager
    {
       Task AddAsync(WareHouseAddModel model ,string header1);

       Task EditAsync(WareHouseEditModel model,string header1);


        Task<WareHouseDetailsDto> GetDetailAsync(int id, int header1);

        Task DeleteAsync(int id,int header1);

        Task<JqDataTableResponse<WareHouseDetailsListDto>> GetPagedResultAsync(WareHouseJqDataTableRequestModel model, int header1);

        Task<IEnumerable<WareHouseDetailsDto>> GetAllAsync(int header1, Constants.RecordStatus? status = null);

    }
}
