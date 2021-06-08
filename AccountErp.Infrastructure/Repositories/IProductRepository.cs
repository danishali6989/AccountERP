using AccountErp.Dtos;
using AccountErp.Dtos.Product;
using AccountErp.Entities;
using AccountErp.Models.Item;
using AccountErp.Models.Product;
using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product entity);

        void Edit(Product entity);

        Task<Product> GetAsync(int id);

        Task<IEnumerable<Product>> GetAsync(List<int> itemIds);

        Task<ProductDetailDto> GetDetailAsync(int id);

        Task<IEnumerable<ProductDetailDto>> GetAllAsync(Constants.RecordStatus? status = null);

        //Task<IEnumerable<ProductDetailDto>> GetAllForSalesAsync(Constants.RecordStatus? status = null);
        //Task<IEnumerable<ProductDetailDto>> GetAllForExpenseAsync(Constants.RecordStatus? status = null);

        Task<ProductDetailForEditDto> GetForEditAsync(int id);

        Task<JqDataTableResponse<ProductListItemDto>> GetPagedResultAsync(ProductJqDataTableRequestModel model);

        Task<JqDataTableResponse<ProductListItemDto>> GetInventoryPagedResultAsync(ProductInventoryJqDataTableRequestModel model);


        Task<IEnumerable<SelectListItemDto>> GetSelectItemsAsync();

        Task ToggleStatusAsync(int id);

        Task DeleteAsync(int id);
        bool checkItemAvailable(int id);
        Task TransferWareHouse(int id, int warehouseId);
        int InvoiceProductCount(int id, DateTime? startDate, DateTime? endDate);
        int BillProductCount(int id, DateTime? startDate, DateTime? endDate);
        int CreditMemoProductCount(int id, DateTime? startDate, DateTime? endDate);
    }
}
