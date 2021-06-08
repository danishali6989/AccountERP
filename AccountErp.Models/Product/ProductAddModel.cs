using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountErp.Models.Product
{
    public class ProductAddModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string IsTaxable { get; set; }
        public int? SalesTaxId { get; set; }
        public int? BankAccountId { get; set; }
        public int? InitialStock { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal BuyingPrice { get; set; }
        public int? ProductCategoryId { get; set; }
        public int? WarehouseId { get; set; }
    }
}
