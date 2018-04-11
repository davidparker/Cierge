using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetSo.Models.ManageViewModels
{
    public class LoginsViewModel
    {
        public IList<UserLoginInfo> Logins { get; set; }
    }
}
