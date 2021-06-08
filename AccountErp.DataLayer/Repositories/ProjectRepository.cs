using AccountErp.Dtos;
using AccountErp.Dtos.Project;
using AccountErp.Entities;
using AccountErp.Infrastructure.Repositories;
using AccountErp.Models.Project;
using AccountErp.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using AccountErp.Dtos.Invoice;
using AccountErp.Dtos.Bill;

namespace AccountErp.DataLayer.Repositories
{
    public class ProjectRepository:IProjectRepository
    { 
   private readonly DataContext _dataContext;

    public ProjectRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddAsync(Project entity)
    {
        await _dataContext.AddAsync(entity);
    }

        public async Task AddProjectTransactionAsync(ProjectTransaction entity)
        {
            await _dataContext.AddAsync(entity);
        }

        public void Edit(Project entity)
    {
        _dataContext.Update(entity);
    }

    public async Task<Project> GetAsync(int id)
    {
        return await _dataContext.Project.FindAsync(id);
    }

    public async Task<IEnumerable<Project>> GetAsync(List<int> itemIds)
    {
        return await _dataContext.Project.Where(x => itemIds.Contains(x.Id)).ToListAsync();
    }

        public async Task<Project> GetAsyncByCustId(int custId)
        {
            return await _dataContext.Project.Where(x => x.CustomerId == custId).FirstOrDefaultAsync();
        }
        public async Task<ProjectDetailDto> GetDetailAsync(int id)
    {
        return await (from s in _dataContext.Project
                      where s.Id == id
                      select new ProjectDetailDto
                      {
                          Id = s.Id,
                          ProjectName = s.ProjectName,
                          CustomerId = s.CustomerId,
                          CustomerName = s.Customer.FirstName,
                          Description = s.Description
                      })
                      .AsNoTracking()
                      .SingleOrDefaultAsync();
    }

    public async Task<ProjectDetailForEditDto> GetForEditAsync(int id)
    {
        return await (from s in _dataContext.Project
                      where s.Id == id
                      select new ProjectDetailForEditDto
                      {
                          Id = s.Id,
                          ProjectName = s.ProjectName,
                          CustomerId = s.CustomerId,
                          CustomerName = s.Customer.FirstName,
                          Description = s.Description
                      })
                     .AsNoTracking()
                     .SingleOrDefaultAsync();
    }

    public async Task<JqDataTableResponse<ProjectListItemDto>> GetPagedResultAsync(ProjectJqDataTableRequestModel model)
    {
        if (model.Length == 0)
        {
            model.Length = Constants.DefaultPageSize;
        }

        var filterKey = model.Search.Value;

        var linqStmt = (from s in _dataContext.Project
                        where s.Status != Constants.RecordStatus.Deleted
                            && (model.FilterKey == null
                            || EF.Functions.Like(s.ProjectName, "%" + model.FilterKey + "%"))
                        select new ProjectListItemDto
                        {
                            Id = s.Id,
                            ProjectName = s.ProjectName,
                            CustomerId = s.CustomerId,
                            CustomerName = s.Customer.FirstName,
                            Description = s.Description
                        })
                        .AsNoTracking();

        var sortExpresstion = model.GetSortExpression();

        var pagedResult = new JqDataTableResponse<ProjectListItemDto>
        {
            RecordsTotal = await _dataContext.Project.CountAsync(x => x.Status != Constants.RecordStatus.Deleted),
            RecordsFiltered = await linqStmt.CountAsync(),
            Data = await linqStmt.OrderBy(sortExpresstion).Skip(model.Start).Take(model.Length).ToListAsync()
        };
        return pagedResult;
    }

    public async Task<IEnumerable<SelectListItemDto>> GetSelectItemsAsync()
    {
            return await _dataContext.Project
                .AsNoTracking()
                .Where(x => x.Status == Constants.RecordStatus.Active)
                .OrderBy(x => x.ProjectName)
                .Select(x => new SelectListItemDto
                {
                    KeyInt = x.Id,
                    Value = x.Customer.FirstName + " " + x.Customer.LastName + "(" + x.ProjectName + ")"
                }).ToListAsync();
    }

        public async Task<List<InvoiceListItemDto>> GetInvoiceByProjectIdAsync(int projectId)
        {
            var linqstmt = await (from i in _dataContext.Project
                                  join c in _dataContext.ProjectTransactions
                                  on i.Id equals c.ProjectId
                                  where i.Id == projectId && i.Status != Constants.RecordStatus.Deleted && c.TransType == Constants.ProjectTransactionType.Invoice
                                  select new InvoiceListItemDto
                                  {
                                      Id = c.Invoice.Id,
                                      CustomerId = c.Invoice.CustomerId,
                                      Description = c.Invoice.Remark,
                                      Tax = c.Invoice.Tax ?? 0,
                                      Amount = c.Invoice.TotalAmount,
                                      CreatedOn = c.Invoice.CreatedOn,
                                      InvoiceDate = c.Invoice.InvoiceDate,
                                      StrInvoiceDate = c.Invoice.StrInvoiceDate,
                                      DueDate = c.Invoice.DueDate,
                                      StrDueDate = c.Invoice.StrDueDate,
                                      PoSoNumber = c.Invoice.PoSoNumber,
                                      InvoiceNumber = c.Invoice.InvoiceNumber,
                                      SubTotal = c.Invoice.SubTotal
                                  })
                            .AsNoTracking()
                            .ToListAsync();

            return linqstmt;
        }

        public async Task<List<BillListItemDto>> GetBillByProjectIdAsync(int projectId)
        {
            var linqstmt = await (from i in _dataContext.Project
                                  join c in _dataContext.ProjectTransactions
                                  on i.Id equals c.ProjectId
                                  where i.Id == projectId && i.Status != Constants.RecordStatus.Deleted && c.TransType == Constants.ProjectTransactionType.Bill
                                  select new BillListItemDto
                                  {
                                      Id = c.Bill.Id,
                                      VendorId = c.Bill.VendorId,
                                      Description = c.Bill.Remark,
                                      Tax = c.Bill.Tax ?? 0,
                                      Amount = c.Bill.TotalAmount,
                                      CreatedOn = c.Bill.CreatedOn,
                                      BillDate = c.Bill.BillDate,
                                      StrBillDate = c.Bill.StrBillDate,
                                      DueDate = c.Bill.DueDate ?? Utility.GetDateTime(),
                                      StrDueDate = c.Bill.StrDueDate,
                                      PoSoNumber = c.Bill.PoSoNumber,
                                      BillNumber = c.Bill.BillNumber,
                                      SubTotal = c.Bill.SubTotal
                                  })
                            .AsNoTracking()
                            .ToListAsync();

            return linqstmt;
        }


        public async Task DeleteAsync(int id)
    {
        var item = await _dataContext.Project.FindAsync(id);
        item.Status = Constants.RecordStatus.Deleted;
        _dataContext.Project.Update(item);

    }

        public async Task<List<InvoiceListItemDto>> GetTop5InvoiceAsync(int projectId)
        {
            var linqstmt =  (from i in _dataContext.Project
                                  join c in _dataContext.ProjectTransactions
                                  on i.Id equals c.ProjectId
                                  join cu in _dataContext.Customers on i.CustomerId equals cu.Id
                                  where i.Id == projectId && i.Status != Constants.RecordStatus.Deleted && c.TransType == Constants.ProjectTransactionType.Invoice
                                  select new InvoiceListItemDto
                                  {
                                      Id = c.Invoice.Id,
                                      CustomerId = c.Invoice.CustomerId,
                                      Description = c.Invoice.Remark,
                                      Tax = c.Invoice.Tax ?? 0,
                                      Amount = c.Invoice.TotalAmount,
                                      CreatedOn = c.Invoice.CreatedOn,
                                      InvoiceDate = c.Invoice.InvoiceDate,
                                      StrInvoiceDate = c.Invoice.StrInvoiceDate,
                                      DueDate = c.Invoice.DueDate,
                                      StrDueDate = c.Invoice.StrDueDate,
                                      PoSoNumber = c.Invoice.PoSoNumber,
                                      InvoiceNumber = c.Invoice.InvoiceNumber,
                                      SubTotal = c.Invoice.SubTotal,
                                      CustomerName = cu.FirstName +" "+ cu.LastName,
                                      TotalAmount = c.Invoice.TotalAmount
                                  })
                            .AsNoTracking();
            return await linqstmt.OrderBy("InvoiceDate asc").Take(5).ToListAsync();
             
        }

        public async Task<List<BillListItemDto>> GetTop5BillAsync(int projectId)
        {
            var linqstmt = (from i in _dataContext.Project
                                  join c in _dataContext.ProjectTransactions
                                  on i.Id equals c.ProjectId
                                  where i.Id == projectId && i.Status != Constants.RecordStatus.Deleted && c.TransType == Constants.ProjectTransactionType.Bill
                                  select new BillListItemDto
                                  {
                                      Id = c.Bill.Id,
                                      VendorId = c.Bill.VendorId,
                                      Description = c.Bill.Remark,
                                      Tax = c.Bill.Tax ?? 0,
                                      Amount = c.Bill.TotalAmount,
                                      CreatedOn = c.Bill.CreatedOn,
                                      BillDate = c.Bill.BillDate,
                                      StrBillDate = c.Bill.StrBillDate,
                                      DueDate = c.Bill.DueDate ?? Utility.GetDateTime(),
                                      StrDueDate = c.Bill.StrDueDate,
                                      PoSoNumber = c.Bill.PoSoNumber,
                                      BillNumber = c.Bill.BillNumber,
                                      SubTotal = c.Bill.SubTotal,
                                      VendorName = c.Bill.Vendor.Name
                                      
                                  })
                           .AsNoTracking();
            return await linqstmt.OrderBy("BillDate asc").Take(5).ToListAsync();
        }


    }
}
