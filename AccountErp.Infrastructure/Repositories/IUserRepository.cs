using AccountErp.Dtos.UserLogin;
using AccountErp.Entities;
using AccountErp.Models.UserLogin;
using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User entity);
        Task LoginAddAsync(LoginModule entity);
        void Edit(User entity);

        Task<User> GetAsync(int id);

        Task<UserDetailDto> GetDetailAsync(int id);

        Task<JqDataTableResponse<UserDetailDto>> GetPagedResultAsync(JqDataTableRequest model);

        Task DeleteAsync(int id);

      Task<UserDetailDto> GetByUserAsync(string username);

     Task<UserDetailDto> Login(UserLoginModel model);
        Task<UserDetailDto> isExist(string email);
        //  Task<JqDataTableResponse<UserDetailDto>> GetAgentPagedResultAsync(JqDataTableRequest model);
        Task LogOut(int id);
        Task saveOtp(string email, int otp);
        Task<UserDetailDto> getOtp(string email);

        Task changePassword(string email, string password);


         Task<JqDataTableResponse<UserDetailDto>> OnlineUserPagedResult(JqDataTableRequest model);
        // Task<JqDataTableResponse<UserDetailDto>> GetOnlyOnlineAgentPagedResultAsync(JqDataTableRequest model);

    }
}
