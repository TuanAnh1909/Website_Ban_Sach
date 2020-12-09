using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class ProducerController : BaseController
    {
        //
        // GET: /Admin/Producer/
        
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ProducerDao();
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
            var producer = new ProducerDao().ViewDetail(id);
            return View(producer);
        }

        [HttpPost]
        public ActionResult Create(Producer producer)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProducerDao();
                long id = dao.Insert(producer);
                if (id > 0)
                {
                    setAlert("Thêm mới NXB thành công", "success");
                    return RedirectToAction("Index", "Producer");
                }
                else
                {
                    ModelState.AddModelError("", "Không thêm được");
                }

            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(Producer producer)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProducerDao();
                var result = dao.Update(producer);
                if (result)
                {
                    setAlert("Cập nhật NXB thành công", "success");
                    return RedirectToAction("Index", "Producer");
                }
                else
                {
                    ModelState.AddModelError("", "Không sửa được");
                }

            }
            return View("Index");


        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProducerDao().Delete(id);
            return RedirectToAction("Index");
        }
	}
}