using AccountErp.Dtos.UserLogin;
using AccountErp.Models.UserLogin;
using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Managers
{
    public interface IUserManager
    {
        Task AddAsync(UserLoginDto model);
        Task LoginAddAsync(UserDetailDto model);
        Task EditAsync(UserLoginDto model);

        Task<UserDetailDto> GetDetailAsync(int id);

        Task<JqDataTableResponse<UserDetailDto>> GetPagedResultAsync(JqDataTableRequest model);
        Task DeleteAsync(int id);
        Task<UserDetailDto> CheckUser(string username);
       Task<UserDetailDto> Login(UserLoginModel model);
       // Task<JqDataTableResponse<UserDetailDto>> GetAgentPagedResultAsync(JqDataTableRequest model);
        Task LogOut(int id);
        Task<UserDetailDto> isExist(string email);
        Task saveOtp(string email, int otp);
        Task<UserDetailDto> getOtp(string email);

        Task changePassword(string email, string password);


        Task<JqDataTableResponse<UserDetailDto>> OnlineUserPagedResult(JqDataTableRequest model);
        //  Task<JqDataTableResponse<UserDetailDto>> GetOnlyOnlineAgentPagedResultAsync(JqDataTableRequest model);
    }
}
