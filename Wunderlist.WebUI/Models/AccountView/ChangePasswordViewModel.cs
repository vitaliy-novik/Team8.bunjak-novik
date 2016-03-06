using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wunderlist.WebUI.Models.AccountView
{
    public class ChangePasswordViewModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string RepeatNewPassword { get; set; }
    }
}