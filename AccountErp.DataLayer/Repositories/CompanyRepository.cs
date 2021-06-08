using AccountErp.Dtos;
using AccountErp.Entities;
using AccountErp.Infrastructure.Repositories;
using AccountErp.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountErp.DataLayer.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _dataContext;

        public CompanyRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<SelectListItemDto>> GetCompanyAsync()
        {
            return await _dataContext.Company
                .AsNoTracking()
                .Where(x => x.CompanyTenantId != null)
                .OrderBy(x => x.CompanyName)
                .Select(x => new SelectListItemDto
                {
                    KeyInt = x.CompanyTenantId,
                    Value = x.CompanyName
                }).ToListAsync();
        }
    }
}
