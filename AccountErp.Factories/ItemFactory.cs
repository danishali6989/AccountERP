using AccountErp.Entities;
using AccountErp.Models.Item;
using AccountErp.Utilities;
using System;

namespace AccountErp.Factories
{
    public class ItemFactory
    {
        public static Item Create(ItemAddModel model, string userId, string header1)
        {
            var item = new Item
            {
                Name = model.Name,
                Rate = model.Rate,
                Description = model.Description,
                IsTaxable = model.IsTaxable?.Equals("1") ?? false,
                SalesTaxId = model.SalesTaxId,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
                isForSell = model.isForSell?.Equals("1") ?? false,
                BankAccountId = model.BankAccountId,
                CompanyTenantId = Convert.ToInt32(header1),


            };
            return item;
        }
        public static void Edit(ItemEditModel model, Item entity, string userId, string header1)
        {
            entity.Name = model.Name;
            entity.Rate = model.Rate;
            entity.Description = model.Description;
            entity.IsTaxable = model.IsTaxable?.Equals("1") ?? false;
            entity.SalesTaxId = entity.IsTaxable ? model.SalesTaxId : null;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
            entity.isForSell = model.isForSell?.Equals("1") ?? false;
            entity.BankAccountId = model.BankAccountId;
            entity.CompanyTenantId = Convert.ToInt32(header1);

        }
    }
}
