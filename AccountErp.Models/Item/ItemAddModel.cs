﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountErp.Models.Item
{
    public class ItemAddModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Rate { get; set; }
        public string Description { get; set; }
        [Required]
        public string IsTaxable { get; set; }
        public int? SalesTaxId { get; set; }
        public string isForSell { get; set; }
        public int? BankAccountId { get; set; }
      //  public int? CompanyTenantId { get; set; }
    }
}
