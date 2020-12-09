using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace BookShop.Controllers
{
    public class AuthorController : Controller
    {
        //
        // GET: /Author/
        public ActionResult Index()
        {
            return View();
        }
        //public PartialViewResult Author()
        //{
        //    var model=new AuthorDao().ListAll();
        //    return PartialView();
        //}
	}
}