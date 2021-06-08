using AccountErp.Dtos;
using AccountErp.Dtos.Item;
using AccountErp.Entities;
using AccountErp.Models.Item;
using AccountErp.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Repositories
{
    public interface IItemRepository
    {
        Task AddAsync(Item entity);

        void Edit(Item entity);

        Task<Item> GetAsync(int id, int header1);

        Task<IEnumerable<Item>> GetAsync(List<int> itemIds);

        Task<ItemDetailDto> GetDetailAsync(int id, int header1);

        Task<IEnumerable<ItemDetailDto>> GetAllAsync(int header1, Constants.RecordStatus? status = null);

        Task<IEnumerable<ItemDetailDto>> GetAllForSalesAsync(int header1, Constants.RecordStatus? status = null);
        Task<IEnumerable<ItemDetailDto>> GetAllForExpenseAsync(int header1, Constants.RecordStatus? status = null);

        Task<ItemDetailForEditDto> GetForEditAsync(int id, int header1);

        Task<JqDataTableResponse<ItemListItemDto>> GetPagedResultAsync(ItemJqDataTableRequestModel model, int header1);

        Task<IEnumerable<SelectListItemDto>> GetSelectItemsAsync(int header1);

        Task ToggleStatusAsync(int id, int header1);
        
        Task DeleteAsync(int id, int header1);
        bool checkItemAvailable(int id);
    }
}
