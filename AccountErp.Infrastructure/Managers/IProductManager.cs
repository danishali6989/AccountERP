using AccountErp.Dtos;
using AccountErp.Dtos.Product;
using AccountErp.Models.Product;
using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Managers
{
    public interface IProductManager
    {
        Task AddAsync(ProductAddModel model);

        Task EditAsync(ProductEditModel model);

        Task<ProductDetailDto> GetDetailAsync(int id);

        Task<ProductDetailForEditDto> GetForEditAsync(int id);

        Task<JqDataTableResponse<ProductListItemDto>> GetPagedResultAsync(ProductJqDataTableRequestModel model);

        Task<JqDataTableResponse<ProductListItemDto>> GetInventoryPagedResultAsync(ProductInventoryJqDataTableRequestModel model);


        Task<IEnumerable<ProductDetailDto>> GetAllAsync(Constants.RecordStatus? status = null);

        //Task<IEnumerable<ProductDetailDto>> GetAllForSalesAsync(Constants.RecordStatus? status = null);


        //Task<IEnumerable<ProductDetailDto>> GetAllForExpenseAsync(Constants.RecordStatus? status = null);




        Task<IEnumerable<SelectListItemDto>> GetSelectItemsAsync();

        Task ToggleStatusAsync(int id);

        Task DeleteAsync(int id);

        bool checkItemAvailable(int id);
        Task TransferWareHouse(int id, int wareHouseId);

    }
}
