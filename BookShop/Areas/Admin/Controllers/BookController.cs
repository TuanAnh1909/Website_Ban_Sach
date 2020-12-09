using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace BookShop.Areas.Admin.Controllers
{
    public class BookController : BaseController
    {
        //
        // GET: /Admin/Book/
        
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new BookDao();
            var model = dao.ListAllpaging(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            setViewbag();
            return View();
        }
        public ActionResult Edit(long id)
        {
            var book= new BookDao().ViewDetail(id);
            setViewbag();
            return View(book);
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                var dao = new BookDao();
                long id = dao.Insert(book);
                if (id > 0)
                {
                    setAlert("Thêm thành công", "success");
                    setViewbag();
                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    ModelState.AddModelError("", "Không thêm được");
                }

            }
            setViewbag();
            return View("Index");
          
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                var dao = new BookDao();
                var result = dao.Update(book);
                if (result)
                {
                    setAlert("Cập nhật sách thành công", "success");
                    setViewbag();
                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    ModelState.AddModelError("", "Không thêm được");
                }

            }
            setViewbag();
            return View("Index");

        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new BookDao().Delete(id);
            return RedirectToAction("Index");
        }
        private void setViewbag(long? matg = null, long? madm=null, long? manxb=null)
        {
            var dao = new AuthorDao();
            

            BookCategoryDao danhmuc = new BookCategoryDao();
            ProducerDao nxb = new ProducerDao();

            ViewBag.AuthorID = new SelectList(dao.ListByID(), "ID", "Name", matg);
            ViewBag.CategoryID = new SelectList(danhmuc.ListAll(), "ID", "Name", madm);
            ViewBag.ProcderID = new SelectList(nxb.ListAll(), "ID", "Name", manxb);
        }
	}
}