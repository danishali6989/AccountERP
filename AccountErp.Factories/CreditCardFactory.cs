using AccountErp.Entities;
using AccountErp.Models.CreditCard;
using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Factories
{
    public class CreditCardFactory
    {
        public static CreditCard Create(CreditCardAddModel model,string userId, string header)
        {
            CreditCard creditCard = new CreditCard()
            {
                Number = model.CreditCardNumber,
                BankName = model.BankName,
                CardHolderName = model.CardHolderName,
                Status = Constants.RecordStatus.Active,
                CreatedBy = "0",
                CreatedOn = Utility.GetDateTime(),
            CompanyTenantId = Convert.ToInt32(header)

            };
            return creditCard;
        }
        public static void Create(CreditCardEditModel model,CreditCard entity,string userId, string header)
        {
            entity.Number = model.CreditCardNumber;
            entity.BankName = model.BankName;
            entity.CardHolderName = model.CardHolderName;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
            entity.CompanyTenantId = Convert.ToInt32(header);

        }
    }
}
