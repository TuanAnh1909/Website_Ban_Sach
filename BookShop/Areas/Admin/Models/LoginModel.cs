using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Mời nhập user name")]
        public String UserName { set; get; }
        [Required(ErrorMessage="Mời nhập password")]
        public String Password { set; get; }
        public bool RememberMe { set; get; }
    }
}