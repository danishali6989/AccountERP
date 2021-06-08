using AccountErp.Dtos;
using AccountErp.Dtos.Item;
using AccountErp.Models.Item;
using AccountErp.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Managers
{
    public interface IItemManager
    {
        Task AddAsync(ItemAddModel model, string header1);

        Task EditAsync(ItemEditModel model, string header1);

        Task<ItemDetailDto> GetDetailAsync(int id, int header1);

        Task<ItemDetailForEditDto> GetForEditAsync(int id, int header1);

        Task<JqDataTableResponse<ItemListItemDto>> GetPagedResultAsync(ItemJqDataTableRequestModel model, int header1);

        Task<IEnumerable<ItemDetailDto>> GetAllAsync(int header1, Constants.RecordStatus? status = null);

        Task<IEnumerable<ItemDetailDto>> GetAllForSalesAsync(int header1, Constants.RecordStatus? status = null);


        Task<IEnumerable<ItemDetailDto>> GetAllForExpenseAsync(int header1, Constants.RecordStatus? status = null);


   

        Task<IEnumerable<SelectListItemDto>> GetSelectItemsAsync(int header1);

        Task ToggleStatusAsync(int id, int header1);

        Task DeleteAsync(int id, int header1);

        bool checkItemAvailable(int id);
    }
}
