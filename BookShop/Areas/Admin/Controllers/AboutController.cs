using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class AboutController : BaseController
    {
        //
        // GET: /Admin/About/
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new AboutDao();
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
            var about = new AboutDao().ViewDetail(id);
            return View(about);
        }

        [HttpPost]
        public ActionResult Create(About about)
        {
            if (ModelState.IsValid)
            {
                var dao = new AboutDao();
                long id = dao.Insert(about);
                if (id > 0)
                {
                    setAlert("Thêm thông tin thành công", "success");
                    return RedirectToAction("Index", "About");
                }
                else
                {
                    setAlert("Cập nhật thông tin thành công", "success");
                    ModelState.AddModelError("", "Không thêm được");
                }
                
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(About about)
        {
            if (ModelState.IsValid)
            {
                var dao = new AboutDao();
                var result = dao.Update(about);
                if(result)
                {
                    return RedirectToAction("Index", "About");
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
            new AboutDao().Delete(id);
            return RedirectToAction("Index");
        }
	}
}