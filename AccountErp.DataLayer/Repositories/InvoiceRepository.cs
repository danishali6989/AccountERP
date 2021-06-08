﻿using AccountErp.Dtos;
using AccountErp.Dtos.Address;
using AccountErp.Dtos.Customer;
using AccountErp.Dtos.Invoice;
using AccountErp.Entities;
using AccountErp.Infrastructure.Repositories;
using AccountErp.Models.Invoice;
using AccountErp.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace AccountErp.DataLayer.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DataContext _dataContext;

        public InvoiceRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Invoice entity)
        {
            await _dataContext.Invoices.AddAsync(entity);
        }

        public void Edit(Invoice entity)
        {

            _dataContext.Invoices.Update(entity);
        }

        public async Task<Invoice> GetAsync(int id, int header)
        {
            return await _dataContext.Invoices
                .Include(x => x.Services)
                .Include(x => x.Attachments)
                .SingleAsync(x => x.Id == id);
        }

        public async Task<InvoiceDetailDto> GetDetailAsync(int id, int header)
        {
            var invoice = await (from i in _dataContext.Invoices
                                 join c in _dataContext.Customers
                                 on i.CustomerId equals c.Id
                                 where i.Id == id && i.CompanyTenantId == header
                                 select new InvoiceDetailDto
                                 {
                                     Id = i.Id,
                                     Tax = i.Tax,
                                     Discount = i.Discount,
                                     TotalAmount = i.TotalAmount,
                                     Remark = i.Remark,
                                     Status = i.Status,
                                     CreatedOn = i.CreatedOn,
                                     InvoiceDate = i.InvoiceDate,
                                     StrInvoiceDate = i.StrInvoiceDate,
                                     DueDate = i.DueDate,
                                     StrDueDate = i.StrDueDate,
                                     PoSoNumber = i.PoSoNumber,
                                     InvoiceNumber = i.InvoiceNumber,
                                     SubTotal = i.SubTotal,
                                     InvoiceType = i.InvoiceType,
                                     Customer = new CustomerDetailDto
                                     {
                                         FirstName = c.FirstName,
                                         LastName = c.LastName,
                                         Email = c.Email,
                                         Phone = c.Phone,
                                         Discount = c.Discount,
                                         Address = new AddressDto
                                         {
                                             StreetNumber = c.Address.StreetNumber,
                                             StreetName = c.Address.StreetName,
                                             City = c.Address.City,
                                             State = c.Address.State,
                                             CountryName = c.Address.Country.Name,
                                             PostalCode = c.Address.PostalCode
                                         }
                                     },
                                     Items = i.InvoiceType == 0 ? i.Services.Select(x => new InvoiceServiceDto
                                     {
                                         Id = x.ServiceId ?? 0,
                                         Type = x.Service.Name,
                                         Rate = x.Rate,
                                         Name = x.Service.Name,
                                         Description = x.Service.Description,
                                         Quantity = x.Quantity,
                                         Price = x.Price,
                                         TaxId = x.TaxId,
                                         TaxPrice = x.TaxPrice,
                                         TaxPercentage = x.TaxPercentage,
                                         LineAmount = x.LineAmount,
                                         BankAccountId = x.Service.BankAccountId,
                                         TaxBankAccountId = x.Taxes.BankAccountId
                                     }) :


                                      i.Services.Select(x => new InvoiceServiceDto
                                      {
                                          Id = x.ProductId ?? 0,
                                          Type = x.Product.Name,
                                          Rate = x.Rate,
                                          Name = x.Product.Name,
                                          Description = x.Product.Description,
                                          Quantity = x.Quantity,
                                          Price = x.Price,
                                          TaxId = x.TaxId,
                                          TaxPrice = x.TaxPrice,
                                          TaxPercentage = x.TaxPercentage,
                                          LineAmount = x.LineAmount,
                                          BankAccountId = x.Product.BankAccountId,
                                          TaxBankAccountId = x.Product.BankAccountId
                                      })
                                     ,
                                     Attachments = i.Attachments.Select(x => new InvoiceAttachmentDto
                                     {
                                         Id = x.Id,
                                         Title = x.Title,
                                         FileName = x.FileName,
                                         OriginalFileName = x.OriginalFileName
                                     })
                                 })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();

            return invoice;
        }

        public async Task<InvoiceDetailDto> GetDetailAsyncforpyment(int id, int header)
        {
            var invoice = await (from i in _dataContext.Invoices
                                 join c in _dataContext.Customers
                                 on i.CustomerId equals c.Id
                                 where i.Id == id && i.CompanyTenantId == header
                                 select new InvoiceDetailDto
                                 {
                                     Id = i.Id,
                                     Tax = i.Tax,
                                     Discount = i.Discount,
                                     TotalAmount = i.TotalAmount,
                                     Remark = i.Remark,
                                     Status = i.Status,
                                     CreatedOn = i.CreatedOn,
                                     InvoiceDate = i.InvoiceDate,
                                     StrInvoiceDate = i.StrInvoiceDate,
                                     DueDate = i.DueDate,
                                     StrDueDate = i.StrDueDate,
                                     PoSoNumber = i.PoSoNumber,
                                     InvoiceNumber = i.InvoiceNumber,
                                     SubTotal = i.SubTotal,
                                     InvoiceType = i.InvoiceType,
                                     Customer = new CustomerDetailDto
                                     {
                                         FirstName = c.FirstName,
                                         LastName = c.LastName,
                                         Email = c.Email,
                                         Phone = c.Phone,
                                         Discount = c.Discount,
                                         Address = new AddressDto
                                         {
                                             StreetNumber = c.Address.StreetNumber,
                                             StreetName = c.Address.StreetName,
                                             City = c.Address.City,
                                             State = c.Address.State,
                                             CountryName = c.Address.Country.Name,
                                             PostalCode = c.Address.PostalCode
                                         }
                                     },
                                     Items = i.InvoiceType == 0 ? i.Services.Select(x => new InvoiceServiceDto
                                     {
                                         Id = x.ServiceId ?? 0,
                                         Type = x.Service.Name,
                                         Rate = x.Rate,
                                         Name = x.Service.Name,
                                         Description = x.Service.Description,
                                         Quantity = x.Quantity,
                                         Price = x.Price,
                                         TaxId = x.TaxId,
                                         TaxPrice = x.TaxPrice,
                                         TaxPercentage = x.TaxPercentage,
                                         LineAmount = x.LineAmount,
                                         BankAccountId = x.Service.BankAccountId,
                                         TaxBankAccountId = x.Taxes.BankAccountId
                                     }) :


                                      i.Services.Select(x => new InvoiceServiceDto
                                      {
                                          Id = x.ProductId ?? 0,
                                          Type = x.Product.Name,
                                          Rate = x.Rate,
                                          Name = x.Product.Name,
                                          Description = x.Product.Description,
                                          Quantity = x.Quantity,
                                          Price = x.Price,
                                          TaxId = x.TaxId,
                                          TaxPrice = x.TaxPrice,
                                          TaxPercentage = x.TaxPercentage,
                                          LineAmount = x.LineAmount,
                                          BankAccountId = x.Product.BankAccountId,
                                          TaxBankAccountId = x.Product.BankAccountId
                                      })
                                     ,
                                     Attachments = i.Attachments.Select(x => new InvoiceAttachmentDto
                                     {
                                         Id = x.Id,
                                         Title = x.Title,
                                         FileName = x.FileName,
                                         OriginalFileName = x.OriginalFileName
                                     })
                                 })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();

            return invoice;
        }


        public async Task<InvoiceDetailForEditDto> GetForEditAsync(int id, int header)
        {
            return await (from i in _dataContext.Invoices
                          join c in _dataContext.Customers
                          on i.CustomerId equals c.Id
                          where i.Id == id && i.CompanyTenantId == header
                          select new InvoiceDetailForEditDto
                          {
                              Id = i.Id,
                              CustomerId = i.CustomerId,
                              Tax = i.Tax,
                              Discount = i.Discount,
                              TotalAmount = i.TotalAmount,
                              Remark = i.Remark,
                              InvoiceDate = i.InvoiceDate,
                              StrInvoiceDate = i.StrInvoiceDate,
                              DueDate = i.DueDate,
                              StrDueDate = i.StrDueDate,
                              PoSoNumber = i.PoSoNumber,
                              InvoiceNumber = i.InvoiceNumber,
                              SubTotal = i.SubTotal,
                              InvoiceType = i.InvoiceType,
                              Status = i.Status,
                              Customer = new CustomerDetailDto
                              {
                                  FirstName = c.FirstName,
                                  LastName = c.LastName,
                                  Phone = c.Phone,
                                  Email = c.Email,
                                  Discount = c.Discount,
                              },
                              Items = i.InvoiceType == 0 ? i.Services.Select(x => new InvoiceServiceDto
                              {
                                  Id = x.ServiceId ?? 0,
                                  Type = x.Service.Name,
                                  Rate = x.Rate,
                                  Name = x.Service.Name,
                                  Description = x.Service.Description,
                                  Quantity = x.Quantity,
                                  Price = x.Price,
                                  TaxId = x.TaxId,
                                  TaxPrice = x.TaxPrice,
                                  TaxPercentage = x.TaxPercentage,
                                  LineAmount = x.LineAmount,
                                  BankAccountId = x.Service.BankAccountId,
                                  TaxBankAccountId = x.Taxes.BankAccountId
                              }) :


                                      i.Services.Select(x => new InvoiceServiceDto
                                      {
                                          Id = x.ProductId ?? 0,
                                          Type = x.Product.Name,
                                          Rate = x.Rate,
                                          Name = x.Product.Name,
                                          Description = x.Product.Description,
                                          Quantity = x.Quantity,
                                          Price = x.Price,
                                          TaxId = x.TaxId,
                                          TaxPrice = x.TaxPrice,
                                          TaxPercentage = x.TaxPercentage,
                                          LineAmount = x.LineAmount,
                                          BankAccountId = x.Product.BankAccountId,
                                          TaxBankAccountId = x.Product.BankAccountId
                                      })
                                     ,
                              Attachments = i.Attachments.Select(x => new InvoiceAttachmentDto
                              {
                                  Id = x.Id,
                                  Title = x.Title,
                                  FileName = x.FileName,
                                  OriginalFileName = x.OriginalFileName
                              })
                          })
                           .AsNoTracking()
                           .SingleOrDefaultAsync();
        }

        public async Task<JqDataTableResponse<InvoiceListItemDto>> GetPagedResultAsync(InvoiceJqDataTableRequestModel model, int header)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }

            var linqstmt = (from i in _dataContext.Invoices
                            join c in _dataContext.Customers
                            on i.CustomerId equals c.Id
                            join cm in _dataContext.CreditMemo
                            on i.Id equals cm.InvoiceId into inv
                            from cm in inv.DefaultIfEmpty()
                            where (model.CustomerId == null
                                    || i.CustomerId == model.CustomerId.Value)
                                && (model.FilterKey == null
                                    || EF.Functions.Like(c.FirstName, "%" + model.FilterKey + "%")
                                     || EF.Functions.Like(c.MiddleName, "%" + model.FilterKey + "%")
                                    || EF.Functions.Like(c.LastName, "%" + model.FilterKey + "%")
                                     || EF.Functions.Like(i.InvoiceNumber, "%" + model.FilterKey + "%"))
                            && i.Status != Constants.InvoiceStatus.Deleted && i.CompanyTenantId == header
                            select new InvoiceListItemDto
                            {
                                Id = i.Id,
                                CustomerId = i.CustomerId,
                                CustomerName = (c.FirstName ?? "") + " " + (c.MiddleName ?? "") + " " + (c.LastName ?? ""),
                                Description = i.Remark,
                                Amount = i.Services.Sum(x => x.Rate),
                                Discount = i.Discount,
                                Tax = i.Tax,
                                TotalAmount = i.TotalAmount,
                                CreatedOn = i.CreatedOn,
                                Status = i.Status,
                                InvoiceNumber = i.InvoiceNumber,
                                SubTotal = i.SubTotal,
                                InvoiceType = i.InvoiceType,
                                CreaditMemoId=cm.Id
                                
                                
                                
                            })
                            .AsNoTracking();

            var sortExpresstion = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<InvoiceListItemDto>
            {
                RecordsTotal = await _dataContext.Invoices.CountAsync(x => x.Status != Constants.InvoiceStatus.Deleted),
                RecordsFiltered = await linqstmt.CountAsync(),
                Data = await linqstmt.OrderBy(sortExpresstion).Skip(model.Start).Take(model.Length).ToListAsync()
            };

            foreach (var invoiceListItemDto in pagedResult.Data)
            {
                invoiceListItemDto.CreatedOn = Utility.GetDateTime(invoiceListItemDto.CreatedOn, null);
            }

            return pagedResult;
        }

        public async Task<JqDataTableResponse<InvoiceListItemDto>> GetTopFiveInvoicesAsync(InvoiceJqDataTableRequestModel model, int header)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }
            model.Order[0].Dir = "desc";
            model.Order[0].Column = 4;
            var linqstmt = (from i in _dataContext.Invoices
                            join c in _dataContext.Customers
                            on i.CustomerId equals c.Id
                            where (model.CustomerId == null
                                    || i.CustomerId == model.CustomerId.Value)
                                && (model.FilterKey == null
                                    || EF.Functions.Like(c.FirstName, "%" + model.FilterKey + "%")
                                    || EF.Functions.Like(c.LastName, "%" + model.FilterKey + "%"))
                            && i.Status != Constants.InvoiceStatus.Deleted && i.CompanyTenantId == header
                            select new InvoiceListItemDto
                            {
                                Id = i.Id,
                                CustomerId = i.CustomerId,
                                CustomerName = (c.FirstName ?? "") + " " + (c.MiddleName ?? "") + " " + (c.LastName ?? ""),
                                Description = i.Remark,
                                Amount = i.Services.Sum(x => x.Rate),
                                Discount = i.Discount,
                                Tax = i.Tax,
                                TotalAmount = i.TotalAmount,
                                CreatedOn = i.CreatedOn,
                                Status = i.Status,
                                InvoiceNumber = i.InvoiceNumber,
                                SubTotal = i.SubTotal
                            })
                            .AsNoTracking().Take(5);

            var sortExpresstion = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<InvoiceListItemDto>
            {
                RecordsTotal = await _dataContext.Invoices.CountAsync(x => model.CustomerId == null || x.CustomerId == model.CustomerId.Value),
                RecordsFiltered = await linqstmt.CountAsync(),
                Data = await linqstmt.OrderBy(sortExpresstion).Skip(model.Start).Take(model.Length).ToListAsync()
            };

            foreach (var invoiceListItemDto in pagedResult.Data)
            {
                invoiceListItemDto.CreatedOn = Utility.GetDateTime(invoiceListItemDto.CreatedOn, null);
            }

            return pagedResult;
        }
        
        public async Task<List<InvoiceListItemDto>> GetRecentAsync(int header)
        {
            var linqstmt = (from i in _dataContext.Invoices
                            join c in _dataContext.Customers
                            on i.CustomerId equals c.Id
                            where i.Status != Constants.InvoiceStatus.Deleted && i.CompanyTenantId == header
                            select new InvoiceListItemDto
                            {
                                Id = i.Id,
                                CustomerId = i.CustomerId,
                                CustomerName = (c.FirstName ?? "") + " " + (c.MiddleName ?? "") + " " + (c.LastName ?? ""),
                                Description = i.Remark,
                                Tax = i.Tax ?? 0,
                                Amount = i.TotalAmount,
                                CreatedOn = i.CreatedOn,
                                InvoiceDate = i.InvoiceDate,
                                StrInvoiceDate = i.StrInvoiceDate,
                                DueDate = i.DueDate,
                                StrDueDate = i.StrDueDate,
                                PoSoNumber = i.PoSoNumber,
                                InvoiceNumber = i.InvoiceNumber,
                                SubTotal = i.SubTotal
                            })
                            .AsNoTracking();

            return await linqstmt.OrderByDescending(x => x.CreatedOn).Take(5).ToListAsync();
        }

        public async Task<List<InvoiceListItemDto>> GetAllUnpaidInvoiceAsync(int header)
        {
            var linqstmt = await (from i in _dataContext.Invoices
                            join c in _dataContext.Customers
                            on i.CustomerId equals c.Id
                            where i.Status != Constants.InvoiceStatus.Deleted && i.Status != Constants.InvoiceStatus.Paid && i.CompanyTenantId == header
                            select new InvoiceListItemDto
                            {
                                Id = i.Id,
                                CustomerId = i.CustomerId,
                                CustomerName = (c.FirstName ?? "") + " " + (c.MiddleName ?? "") + " " + (c.LastName ?? ""),
                                Description = i.Remark,
                                Tax = i.Tax ?? 0,
                                Amount = i.TotalAmount,
                                CreatedOn = i.CreatedOn,
                                InvoiceDate = i.InvoiceDate,
                                StrInvoiceDate = i.StrInvoiceDate,
                                DueDate = i.DueDate,
                                StrDueDate = i.StrDueDate,
                                PoSoNumber = i.PoSoNumber,
                                InvoiceNumber = i.InvoiceNumber,
                                SubTotal = i.SubTotal
                            })
                            .AsNoTracking()
                            .ToListAsync();

                         return linqstmt;
        }

        public async Task<InvoiceSummaryDto> GetSummaryAsunc(int id)
        {
            return await (from i in _dataContext.Invoices
                          join c in _dataContext.Customers
                            on i.CustomerId equals c.Id
                          where i.Id == id 
                          select new InvoiceSummaryDto
                          {
                              Id = i.Id,
                              CustomerId = c.Id,
                              FirstName = c.FirstName,
                              MiddleName = c.MiddleName,
                              LastName = c.LastName,
                              Amount = i.Services.Sum(x => x.Rate),
                              Tax = i.Tax,
                              Discount = i.Discount,
                              TotalAmount = i.TotalAmount,
                              Description = i.Remark,
                              Status = i.Status,
                              CreatedOn = i.CreatedOn,
                              InvoiceDate = i.InvoiceDate,
                              StrInvoiceDate = i.StrInvoiceDate,
                              DueDate = i.DueDate,
                              StrDueDate = i.StrDueDate,
                              PoSoNumber = i.PoSoNumber,
                              InvoiceNumber = i.InvoiceNumber,
                              InvoiceType = i.InvoiceType
                          })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();
        }

        public async Task UpdateStatusAsync(int id, Constants.InvoiceStatus status)
        {
            var invoice = await _dataContext.Invoices.FindAsync(id);
            invoice.Status = status;
            _dataContext.Invoices.Update(invoice);
        }

        public async Task DeleteAsync(int id, int header)
        {
            var invoice = await _dataContext.Invoices.FindAsync(id);
            invoice.Status = Constants.InvoiceStatus.Deleted;
            _dataContext.Invoices.Update(invoice);
        }

        public async Task<int> getCount(int header)
        {
            int count = await _dataContext.Invoices.CountAsync();
            return count;
        }

        public async Task<List<InvoiceListTopTenDto>> GetTopTenInvoicesAsync(int header)
        {
            var linqstmt = await (from i in _dataContext.Invoices
                                  join c in _dataContext.Customers
                                  on i.CustomerId equals c.Id
                                  where i.Status != Constants.InvoiceStatus.Deleted && i.Status == Constants.InvoiceStatus.Overdue && i.CompanyTenantId == header
                                  select new InvoiceListTopTenDto
                                  {
                                      Id = i.Id,
                                      CustomerId = c.Id,
                                      CustomerName = (c.FirstName ?? "") + " " + (c.MiddleName ?? "") + " " + (c.LastName ?? ""),
                                      InvoiceNumber = i.InvoiceNumber,
                                      Amount = i.Services.Sum(x => x.Rate),
                                      TotalAmount = i.TotalAmount,
                                      InvoiceDate = i.InvoiceDate

                                  }).AsNoTracking().OrderBy("InvoiceDate ASC").ToListAsync();
                            //.AsNoTracking().Take(5).OrderBy("InvoiceDate ASC").ToListAsync();

            return linqstmt;
        }

        public async Task<IEnumerable<SelectListItemDto>> GetSelectInoviceAsync(int header)
        {
            return await _dataContext.Invoices
                .AsNoTracking()
                .Where(x => x.Status != Constants.InvoiceStatus.Deleted && x.InvoiceType == Constants.InvoiceType.Product && x.CompanyTenantId == header)
                .OrderBy(x => x.InvoiceNumber)
                .Select(x => new SelectListItemDto
                {
                    KeyInt = x.Id,
                    Value = x.InvoiceNumber
                }).ToListAsync();
        }

    }
}
