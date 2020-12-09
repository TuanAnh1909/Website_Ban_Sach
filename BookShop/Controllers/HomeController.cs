using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using BookShop.Models;

namespace BookShop.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            var dao=new BookDao();
            //var model = dao.Search(search);
            //ViewBag.search = search;
            return View();
        }
        [ChildActionOnly]//khong the goi truc tiep den trang
        public ActionResult MainMenu()
        {
            var model = new ManuDao().ListByGroupID(1);
            return PartialView(model);
        }
        [ChildActionOnly]//khong the goi truc tiep den trang
        public ActionResult TopMenu()
        {
            var model = new ManuDao().ListByGroupID(2);
            return PartialView(model);
        }
        [ChildActionOnly]//khong the goi truc tiep den trang
        public ActionResult Footer()
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }
        [ChildActionOnly]//khong the goi truc tiep den trang
        public ActionResult Slide()
        {
            var model = new SlideDao().ListAll();
            return PartialView(model);
        }
        [ChildActionOnly]//khong the goi truc tiep den trang
        public ActionResult BookNew()
        {
            var model = new BookDao().ListNewBook(4);
            return PartialView(model);
        }
        [ChildActionOnly]//khong the goi truc tiep den trang
        public ActionResult BookTop()
        {
            var model = new BookDao().ListHotBook(4);
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult BookCategory()
        {
            var model = new BookCategoryDao().ListAll();
            return PartialView(model);

        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[Common.ComonConst.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
           
            return PartialView(list);

        }
        [ChildActionOnly]
        public ActionResult ListAuthor()
        {
            var model = new AuthorDao().ListByID();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult ListProducer()
        {
            var model = new ProducerDao().ListByID();
            return PartialView(model);
        }
        
    }
}