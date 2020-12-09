using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace BookShop.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Category(long Ca_id)
        {
            var category = new BookCategoryDao().ViewDetail(Ca_id);
            ViewBag.Category = category;
            var model = new BookDao().ListByCategoryID(Ca_id);
            return View(model);
        }
        public ActionResult Author(long Au_id)
        {
            var author = new AuthorDao().ViewDetail(Au_id);
            ViewBag.Author = author;
            var model = new BookDao().ListByAuthor(Au_id);
            return View(model);
        }
        public ActionResult Producer(long Pro_id)
        {
            var pro = new ProducerDao().ViewDetail(Pro_id);
            ViewBag.Producer = pro;
            var model = new BookDao().ListByProducer(Pro_id);
            return View(model);
        }
        public ActionResult Detail(long id)
        {
            var book = new BookDao().ViewDetail(id);
            ViewBag.Category = new BookCategoryDao().ViewDetail(book.CategoryID.Value);
            ViewBag.RelatedBook = new BookDao().ListRelateBook(id);
            if (book == null)
            {
                Response.StatusCode = 404;
            }
            return View(book);
        }

	}
}