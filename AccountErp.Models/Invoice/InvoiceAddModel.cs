﻿using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountErp.Models.Invoice
{
    public class InvoiceAddModel
    {
        [Required]
        public int CustomerId { get; set; }

        public decimal? Tax { get; set; }

        public decimal? Discount { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public string Remark { get; set; }

        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal? PoSoNumber { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? LineAmountSubTotal { get; set; }

        public Constants.InvoiceType InvoiceType { get; set; }
        [Required]
        public List<InvoiceServiceModel> Items { get; set; }

        public List<InvoiceAttachmentAddModel> Attachments { get; set; }
    }
}
