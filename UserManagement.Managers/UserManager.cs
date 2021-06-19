using UserManagement.Dtos.UserLogin;
using UserManagement.Factories;
using UserManagement.Infrastructure.DataLayer;
using UserManagement.Infrastructure.Managers;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Models.UserLogin;
using UserManagement.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public UserManager(IHttpContextAccessor contextAccessor,
          IUserRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(UserLoginDto model)
        {
            await _repository.AddAsync(UserFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task LoginAddAsync(UserDetailDto model)
        {
            await _repository.LoginAddAsync(UserFactory.Login(model));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(UserLoginDto model)
        {
            var item = await _repository.GetAsync(model.Id);
            UserFactory.Create(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UserDetailDto> GetDetailAsync(int id)
        {
            return await _repository.GetDetailAsync(id);
        }

        public async Task<JqDataTableResponse<UserDetailDto>> GetPagedResultAsync(JqDataTableRequest model)
        {
            return await _repository.GetPagedResultAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<UserDetailDto> CheckUser(string username)
        {
            return await _repository.GetByUserAsync(username);
        }
        public async Task<UserDetailDto> Login(UserLoginModel model)
        {
            return await _repository.Login(model);
        }
        /* public async Task<JqDataTableResponse<UserDetailDto>> GetAgentPagedResultAsync(JqDataTableRequest model)
         {
             return await _repository.GetAgentPagedResultAsync(model);
         }*/

        public async Task LogOut(int id)
        {
            await _repository.LogOut(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task saveOtp(string email, int otp)
        {
            await _repository.saveOtp(email,otp);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task changePassword(string email, string password)
        {
            await _repository.changePassword(email, password);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<UserDetailDto> isExist(string email)
        {
            try
            {
                return await _repository.isExist(email);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDetailDto> getOtp(string email)
        {
            return await _repository.getOtp(email);
        }
        public async Task<JqDataTableResponse<UserDetailDto>> OnlineUserPagedResult(JqDataTableRequest model)
        {
            return await _repository.OnlineUserPagedResult(model);
        }

        /* public async Task<JqDataTableResponse<UserDetailDto>> GetOnlyOnlineAgentPagedResultAsync(JqDataTableRequest model)
         {
             return await _repository.GetOnlyOnlineAgentPagedResultAsync(model);
         }*/

    }
}