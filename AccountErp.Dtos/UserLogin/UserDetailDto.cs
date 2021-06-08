using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Dtos.UserLogin
{
    public class UserDetailDto
    {
        public int Id { get; set; }
        public string Usr_FName { get; set; }
        public string Usr_LName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool CallStatus { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public int CompanyTenantId { get; set; }
        public string App_id { get; set; }
        public int Finance_year { get; set; }
        public string Ip_Address { get; set; }
        public string CompanyName { get; set; }
        public int OTP { get; set; }




    }
}
