using AccountErp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.DataLayer.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.SellingPrice).IsRequired().HasColumnType("NUMERIC(12,2)");
            builder.Property(x => x.BuyingPrice).IsRequired().HasColumnType("NUMERIC(12,2)");
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.IsTaxable).IsRequired();
            builder.Property(x => x.SalesTaxId).IsRequired(false);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.UpdatedBy).HasMaxLength(40);
            builder.Property(x => x.BankAccountId).IsRequired(false);
            builder.Property(x => x.InitialStock).IsRequired(false);
            builder.Property(x => x.ProductCategoryId).IsRequired(false);

            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.ProductCategoryId);
            builder.HasOne(x => x.Warehouse).WithMany().HasForeignKey(x => x.WareHouseId);

        }
    }
}