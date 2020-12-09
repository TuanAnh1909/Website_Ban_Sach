using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;

namespace BookShop.Controllers
{
    public class BookCategoryController : Controller
    {
        //
        // GET: /Book/
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult BookCategory()
        {
           
            var model=new BookCategoryDao().ListAll();
            return PartialView(model);
        }
        
	}
}