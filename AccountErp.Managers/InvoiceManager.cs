using AccountErp.Dtos;
using AccountErp.Dtos.Invoice;
using AccountErp.Factories;
using AccountErp.Infrastructure.DataLayer;
using AccountErp.Infrastructure.Managers;
using AccountErp.Infrastructure.Repositories;
using AccountErp.Models.Invoice;
using AccountErp.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountErp.Managers
{
    public class InvoiceManager : IInvoiceManager
    {
    

        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IItemRepository _itemRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICreditMemoRepository _creditMemoRepository;
        private readonly IProjectRepository _ProjectRepository;

        private readonly string _userId;

        public InvoiceManager(IHttpContextAccessor contextAccessor,
            IInvoiceRepository invoiceRepository,
            IUnitOfWork unitOfWork,
            IItemRepository itemRepository,
             ITransactionRepository transactionRepository,
            ICustomerRepository customerRepository,
           ICreditMemoRepository creditMemoRepository,
           IProjectRepository projectRepository)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _invoiceRepository = invoiceRepository;
            _itemRepository = itemRepository;
            _customerRepository = customerRepository;
            _transactionRepository = transactionRepository;
            _creditMemoRepository = creditMemoRepository;
            _unitOfWork = unitOfWork;
            _ProjectRepository = projectRepository;
        }


        public async Task AddAsync(InvoiceAddModel model, string header)
        {
            // var items = (await _itemRepository.GetAsync(model.Items)).ToList();

            //model.TotalAmount = items.Sum(x => x.Rate);

            //model.Tax = items.Where(x => x.IsTaxable).Sum(x => x.Rate * x.SalesTax.TaxPercentage / 100);

            //var customer = await _customerRepository.GetAsync(model.CustomerId);

            //if (customer.Discount != null)
            //{
            //    model.Discount = model.TotalAmount * customer.Discount / 100;
            //    model.TotalAmount = model.TotalAmount - (model.Discount ?? 0);
            //}

            //if (model.Tax != null)
            //{
            //    model.TotalAmount = model.TotalAmount + (model.Tax ?? 0);
            //}
            model.LineAmountSubTotal = model.Items.Sum(x => x.LineAmount);

            var count = await _invoiceRepository.getCount(Convert.ToInt32(header));

            //await _invoiceRepository.AddAsync(InvoiceFactory.Create(model, _userId, items));


            var invoice = InvoiceFactory.Create(model, _userId, count, header);
            await _invoiceRepository.AddAsync(invoice);
            await _unitOfWork.SaveChangesAsync();
            //this for Project 
            var projectData = await _ProjectRepository.GetAsyncByCustId(model.CustomerId);
            if (projectData != null)
            {
                await _ProjectRepository.AddProjectTransactionAsync(ProjectFactory.CreateByInvoice(invoice, projectData.Id, _userId));
                await _unitOfWork.SaveChangesAsync();
            }

            var transaction = TransactionFactory.CreateByInvoice(invoice);
            await _transactionRepository.AddAsync(transaction);
            await _unitOfWork.SaveChangesAsync();

            var itemsList = (model.Items.GroupBy(l => l.BankAccountId, l => new { l.BankAccountId, l.LineAmount })
        .Select(g => new { GroupId = g.Key, Values = g.ToList() })).ToList();

            foreach(var item in itemsList)
            {
                var id = item.GroupId;
                var amount = item.Values.Sum(x => x.LineAmount);

                var itemsData = TransactionFactory.CreateByInvoiceItemsAndTax(invoice,id, amount);
                await _transactionRepository.AddAsync(itemsData);
                await _unitOfWork.SaveChangesAsync();
            }

            var taxlistList = (model.Items.GroupBy(l => l.TaxBankAccountId, l => new { l.TaxBankAccountId, l.TaxPrice })
       .Select(g => new { GroupId = g.Key, Values = g.ToList() })).ToList();

            foreach (var tax in taxlistList)
            {
                if(tax.GroupId > 0)
                {
                    var id = tax.GroupId;
                    var amount = tax.Values.Sum(x => x.TaxPrice);

                    var taxData = TransactionFactory.CreateByInvoiceItemsAndTax(invoice, id, amount);
                    await _transactionRepository.AddAsync(taxData);
                    await _unitOfWork.SaveChangesAsync();
                }
               
            }

        }

        public async Task EditAsync(InvoiceEditModel model, string header)
        {
            //var items = (await _itemRepository.GetAsync(model.Items)).ToList();

            //model.TotalAmount = items.Sum(x => x.Rate);

            //model.Tax = items.Where(x => x.IsTaxable).Sum(x => x.Rate * x.SalesTax.TaxPercentage / 100);

            //var customer = await _customerRepository.GetAsync(model.CustomerId);

            //if (customer.Discount != null)
            //{
            //    model.Discount = model.TotalAmount * customer.Discount / 100;
            //    model.TotalAmount = model.TotalAmount - (model.Discount ?? 0);
            //}

            //if (model.Tax != null)
            //{
            //    model.TotalAmount = model.TotalAmount + (model.Tax ?? 0);
            //}
            await _transactionRepository.DeleteTransaction(model.Id);
            var invoice = await _invoiceRepository.GetAsync(model.Id, Convert.ToInt32(header));

            //InvoiceFactory.Create(model, invoice, _userId, items);
            InvoiceFactory.EditInvoice(model, invoice, _userId, header);

            _invoiceRepository.Edit(invoice);

            await _unitOfWork.SaveChangesAsync();
            var transaction = TransactionFactory.CreateByInvoice(invoice);
            await _transactionRepository.AddAsync(transaction);
            await _unitOfWork.SaveChangesAsync();

            var itemsList = (model.Items.GroupBy(l => l.BankAccountId, l => new { l.BankAccountId, l.LineAmount })
        .Select(g => new { GroupId = g.Key, Values = g.ToList() })).ToList();

            foreach (var item in itemsList)
            {
                var id = item.GroupId;
                var amount = item.Values.Sum(x => x.LineAmount);

                var itemsData = TransactionFactory.CreateByInvoiceItemsAndTax(invoice, id, amount);
                await _transactionRepository.AddAsync(itemsData);
                await _unitOfWork.SaveChangesAsync();
            }

            var taxlistList = (model.Items.GroupBy(l => l.TaxBankAccountId, l => new { l.TaxBankAccountId, l.TaxPrice })
       .Select(g => new { GroupId = g.Key, Values = g.ToList() })).ToList();

            foreach (var tax in taxlistList)
            {
                if (tax.GroupId > 0)
                {
                    var id = tax.GroupId;
                    var amount = tax.Values.Sum(x => x.TaxPrice);

                    var taxData = TransactionFactory.CreateByInvoiceItemsAndTax(invoice, id, amount);
                    await _transactionRepository.AddAsync(taxData);
                    await _unitOfWork.SaveChangesAsync();
                }

            }
        }

        public async Task<InvoiceDetailDto> GetDetailAsync(int id, int header)
        {
            return await _invoiceRepository.GetDetailAsync(id, header);
        }
        public async Task<InvoiceDetailDto> GetDetailAsyncforpyment(int id, int header)
        {
            return await _invoiceRepository.GetDetailAsyncforpyment(id, header);
        }

        public async Task<InvoiceDetailForEditDto> GetForEditAsync(int id, int header)
        {
            return await _invoiceRepository.GetForEditAsync(id, header);
        }

        public async Task<JqDataTableResponse<InvoiceListItemDto>> GetPagedResultAsync(InvoiceJqDataTableRequestModel model, int header)
        {
            return await _invoiceRepository.GetPagedResultAsync(model, header);
        }

        public async Task<JqDataTableResponse<InvoiceListItemDto>> GetTopFiveInvoicesAsync(InvoiceJqDataTableRequestModel model, int header)
        {
            return await _invoiceRepository.GetTopFiveInvoicesAsync(model, header);
        }

        

        public async Task<List<InvoiceListItemDto>> GetRecentAsync(int header)
        {
            return await _invoiceRepository.GetRecentAsync(header);
        }

        public async Task<List<InvoiceListItemDto>> GetAllUnpaidInvoiceAsync(int header)
        {
            return await _invoiceRepository.GetAllUnpaidInvoiceAsync(header);
        }

        public async Task<InvoiceSummaryDto> GetSummaryAsunc(int id, int header)
        {
            return await _invoiceRepository.GetSummaryAsunc(id);
        }

        public async Task DeleteAsync(int id, int header)
        {
            await _invoiceRepository.DeleteAsync(id, header);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> GetInvoiceNumber(int header)
        {
            var count = await _invoiceRepository.getCount(header);
            return (count + 1);
        }
        /*public async Task<List<InvoiceListTopTenDto>> GetTopTenInvoicesAsync()
        {
            InvoiceCountDto invoiceCountDto = new InvoiceCountDto();
            List<InvoiceListTopTenDto> invoiceListTopTens =  await _invoiceRepository.GetTopTenInvoicesAsync();
            invoiceCountDto.InvoiceListTopTensList = invoiceListTopTens.Take(5).ToList();
            invoiceCountDto.Count = invoiceListTopTens.Count;
            return invoiceListTopTens;
        }*/
        public async Task<InvoiceCountDto> GetTopTenInvoicesAsync(int header)
        {
            InvoiceCountDto invoiceCountDto = new InvoiceCountDto();
            List<InvoiceListTopTenDto> invoiceListTopTens = await _invoiceRepository.GetTopTenInvoicesAsync(header);
            invoiceCountDto.InvoiceListTopTensList = invoiceListTopTens.Take(5).ToList();
            invoiceCountDto.Count = invoiceListTopTens.Count;
            return invoiceCountDto;
        }

        public async Task<IEnumerable<SelectListItemDto>> GetSelectInoviceAsync(int header)
        {
            return await _invoiceRepository.GetSelectInoviceAsync(header);
        }
    }
}
