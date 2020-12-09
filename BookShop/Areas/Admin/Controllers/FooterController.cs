using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class FooterController : BaseController
    {
        //
        // GET: /Admin/Footer/
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(long id)
        {
            var footer = new FooterDao().ViewDetail(id);
            return View(footer);
        }

        [HttpPost]
        public ActionResult Create(Footer footer)
        {
            if (ModelState.IsValid)
            {
                var dao = new FooterDao();
                string id = dao.Insert(footer);
                return RedirectToAction("Index", "Footer");
            }
            else
                {
                    ModelState.AddModelError("", "Không thêm được");
                }

            
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(Footer footer)
        {
            if (ModelState.IsValid)
            {
                var dao = new FooterDao();
                var result = dao.Update(footer);
                if (result)
                {
                    return RedirectToAction("Index", "Footer");
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
            new FooterDao().Delete(id);
            return RedirectToAction("Index");
        }
	}
}