using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        //
        // GET: /Admin/Menu/
        public ActionResult Index()
        {
            return View();
        }
	}
}