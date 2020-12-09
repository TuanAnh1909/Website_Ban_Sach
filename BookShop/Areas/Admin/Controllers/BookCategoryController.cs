using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class BookCategoryController : BaseController
    {
        //
        // GET: /Admin/Category/
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new BookCategoryDao();
            var model = dao.ListAllpaging(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(long id)
        {
            var category = new BookCategoryDao().ViewDetail(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Create(BookCategory category)
        {
            if (ModelState.IsValid)
            {
                var dao = new BookCategoryDao();
                long id = dao.Insert(category);
                if (id > 0)
                {
                    setAlert("Thêm danh mục  thành công", "success");
                    return RedirectToAction("Index", "BookCategory");
                }
                else
                {
                    ModelState.AddModelError("", "Không thêm được");
                }

            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(BookCategory category)
        {
            if (ModelState.IsValid)
            {
                var dao = new BookCategoryDao();
                var result = dao.Update(category);
                if (result)
                {
                    setAlert("Cập nhật danh mục thành công","success");
                    return RedirectToAction("Index", "BookCategory");
                }
                else
                {
                    ModelState.AddModelError("", "Không thể cập nhật");
                }

            }
            return View("Index");


        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new BookCategoryDao().Delete(id);
            return RedirectToAction("Index");
        }
	}
}