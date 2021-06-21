using UserManagement.Entities;
using UserManagement.Models.UserAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Factories
{
    public class UserScreenAccessFactory
    {
        public static void CreateUserScreenAccess(ScreenAccessModel model, List<UserScreenAccess> entities)
        {

            //foreach (var item in model)
            //{
            var ids = model.ScreenId.Split(",");
            for(var i =0; i < ids.Length; i++)
            {
                var data = new UserScreenAccess
                {
                    //  Id = Guid.NewGuid(),
                    UserRoleId = model.UserRoleId,
                    ScreenId =Convert.ToInt32(ids[i]),
                    CanAccess = model.CanAccess
                };
                entities.Add(data);
            }
               

              
            //}
        }
    }
}
