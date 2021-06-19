using UserManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Infrastructure.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<SelectListItemDto>> GetCompanyAsync();

    }
}
