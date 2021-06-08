﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Models.Invoice
{
    public class InvoiceServiceModel
    {
        public int? ServiceId { get; set; }
        public int? ProductId { get; set; }
        public decimal Rate { get; set; }
        public decimal Price { get; set; }
        public int? TaxId { get; set; }
        public decimal? TaxPrice { get; set; }
        public decimal? TaxPercentage { get; set; }
        public int Quantity { get; set; }
        public int TaxBankAccountId { get; set; }
        public int BankAccountId { get; set; }
        public decimal LineAmount { get; set; }
    }
}
