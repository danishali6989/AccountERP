using UserManagement.Dtos.UserAccess;
using UserManagement.Models.UserAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Infrastructure.Managers
{
    public interface IUserAccessMAnager
    {
        Task AddUserScreenAccessAsync(ScreenAccessModel model);
        Task<List<ScreenAccessDto>> GetUserScreenAccessById(int id);
        Task<List<ScreendetailDto>> GetAllScreenDetail();
    }
}
