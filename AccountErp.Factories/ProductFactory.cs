using AccountErp.Entities;
using AccountErp.Models.Product;
using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Factories
{
    public class ProductFactory
    {
        public static Product Create(ProductAddModel model, string userId)
        {
            var prod = new Product
            {
                Name = model.Name,
                SellingPrice = model.SellingPrice,
                BuyingPrice = model.BuyingPrice,
                InitialStock = model.InitialStock,
                Description = model.Description,
                IsTaxable = model.IsTaxable?.Equals("1") ?? false,
                SalesTaxId = model.SalesTaxId,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
                BankAccountId = model.BankAccountId,
                ProductCategoryId = model.ProductCategoryId,
                WareHouseId = model.WarehouseId
            };
            return prod;
        }
        public static void Create(ProductEditModel model, Product entity, string userId)
        {
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.IsTaxable = model.IsTaxable?.Equals("1") ?? false;
            entity.SalesTaxId = entity.IsTaxable ? model.SalesTaxId : null;
            entity.UpdatedBy = userId ?? "0";
            entity.SellingPrice = model.SellingPrice;
            entity.BuyingPrice = model.BuyingPrice;
            entity.InitialStock = model.InitialStock;
            entity.UpdatedOn = Utility.GetDateTime();
            entity.BankAccountId = model.BankAccountId;
            entity.ProductCategoryId = model.ProductCategoryId;
            entity.WareHouseId = model.WarehouseId;
        }
    }
}
