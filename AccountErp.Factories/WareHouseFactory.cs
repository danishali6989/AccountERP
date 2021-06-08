using AccountErp.Entities;
using AccountErp.Models.WareHouse;
using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Factories
{
   public class WareHouseFactory
    {
        public static WareHouse Create(WareHouseAddModel model, string userId ,string header1)

        {


            var prod = new WareHouse
            {
                Name = model.Name,
                Location = model.Location,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
                CompanyTenantId=Convert.ToInt32(header1),
               
            };
            return prod;
        }
        public static void Create(WareHouseEditModel model, WareHouse entity, string userId, string header1)
        {
            entity.Name = model.Name;
            entity.Location = model.Location;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
            entity.CompanyTenantId = Convert.ToInt32(header1);
           
            
          
        }
    }
}
