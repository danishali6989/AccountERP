using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Models.UserAccess
{
    public class ScreenAccessModel
    {
        public int UserRoleId { get; set; }
        public int ScreenId { get; set; }
        public bool CanAccess { get; set; }
    }
}
