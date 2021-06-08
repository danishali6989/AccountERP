﻿using AccountErp.Dtos.UserLogin;
using AccountErp.Entities;
using AccountErp.Models.UserLogin;
using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Factories
{
    public class UserFactory
    {
        public static User Create(UserLoginDto model, string userId)
        {
            var data = new User
            {
                Usr_FName = model.FirstName,
                Usr_LName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
                App_id=model.App_id,
                Finance_year=model.Finance_year,
                Ip_Address=model.Ip_Address,
                Password = Utility.Encrypt(model.Password),
                Mobile = model.Mobile,
                RoleId = model.RoleId,

                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
                CompanyTenantId = model.CompanyTenantId,
               
            };
            return data;
        }
        public static void Create(UserLoginDto model, User entity, string userId)
        {
            entity.Usr_FName = model.FirstName;
            entity.Usr_LName = model.LastName;
            entity.UserName = model.UserName;
            entity.Email = model.Email;
            entity.RoleId = model.RoleId;
          //  entity.Password = Utility.Encrypt(model.Password);
            entity.Mobile = model.Mobile;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
            entity.Ip_Address = model.Ip_Address;
            entity.Finance_year = model.Finance_year;
            entity.App_id = model.App_id;
            entity.CompanyTenantId = model.CompanyTenantId;
        }


        public static LoginModule Login(UserDetailDto model)
        {
            var data = new LoginModule
            {
                UserId = model.Id,
                status = true,
                createdOn = Utility.GetDateTime(),
                RoleId = model.RoleId,
                CompanyTenantId = model.CompanyTenantId
               
            };
            return data;
        }
    }
}
