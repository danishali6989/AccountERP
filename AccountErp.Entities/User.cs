using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Usr_FName { get; set; }
        public string Usr_LName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public int RoleId { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public UserRole Role { get; set; }
        public string App_id { get; set; }
        public int Finance_year { get; set; }
        public string Ip_Address { get; set; }
        public int CompanyTenantId { get; set; }
        public Company Company { get; set; }

        public int OTP { get; set;}
    }
}
