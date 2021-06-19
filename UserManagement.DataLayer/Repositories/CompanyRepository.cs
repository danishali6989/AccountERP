using UserManagement.Dtos;
using UserManagement.Entities;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.DataLayer.Repositories
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
                .Where(x => x.CompanyId != null)
                .OrderBy(x => x.CompanyName)
                .Select(x => new SelectListItemDto
                {
                    KeyInt = x.CompanyId,
                    Value = x.CompanyName
                }).ToListAsync();
        }
    }
}
