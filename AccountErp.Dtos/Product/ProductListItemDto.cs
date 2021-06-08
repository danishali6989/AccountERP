using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Dtos.Product
{
    public class ProductListItemDto
    {
        public int Id { get; set; }
        public decimal Percentage { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }

        public string TaxCode { get; set; }
        public decimal? TaxPercentage { get; set; }
        public int? BankAccountId { get; set; }
        public int? InitialStock { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal BuyingPrice { get; set; }
        public string CayegoryName { get; set; }
        public int? ProductCategoryId { get; set; }
        public int? WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public Constants.RecordStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}
