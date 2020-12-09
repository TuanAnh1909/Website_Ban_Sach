using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;


namespace BookShop.Areas.Admin.Controllers
{
    public class FeedBackController : BaseController
    {
        //
        // GET: /Admin/FeedBack/
        
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new FeedBackDao();
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
            var feedback = new FeedBackDao().ViewDetail(id);
            return View(feedback);
        }

        [HttpPost]
        public ActionResult Create(FeedBack feedback)
        {
            if (ModelState.IsValid)
            {
                var dao = new FeedBackDao();
                long id = dao.Insert(feedback);
                if (id > 0)
                {
                    return RedirectToAction("Index", "FeedBack");
                }
                else
                {
                    ModelState.AddModelError("", "Không thêm được");
                }

            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(FeedBack feedback)
        {
            if (ModelState.IsValid)
            {
                var dao = new FeedBackDao();
                var result = dao.Update(feedback);
                if (result)
                {
                    return RedirectToAction("Index", "FeedBack");
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
            new FeedBackDao().Delete(id);
            return RedirectToAction("Index");
        }
	}
}