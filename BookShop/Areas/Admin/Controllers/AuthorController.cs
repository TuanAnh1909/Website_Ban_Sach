using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace BookShop.Areas.Admin.Controllers
{
    public class AuthorController : BaseController
    {
        //
        // GET: /Admin/Author/
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new AuthorDao();
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
            var author = new AuthorDao().ViewDetail(id);
            return View(author);
        }

        [HttpPost]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                var dao = new AuthorDao();
                long id = dao.Insert(author);
                if (id > 0)
                {
                    setAlert("Thêm tác giả thành công", "success");
                    return RedirectToAction("Index", "Author");
                }
                else
                {
                    ModelState.AddModelError("", "Không thêm được");
                }
                
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                var dao = new AuthorDao();
                var result = dao.Update(author);
                if(result)
                {
                    setAlert("Cập nhật tác giả thành công", "success");
                    return RedirectToAction("Index", "Author");
                }
                else
                {
                    ModelState.AddModelError("", "Không thêm được");
                }
                
            }
            return View("Index");
            

        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new AuthorDao().Delete(id);
            return RedirectToAction("Index");
        }
	}
	}
