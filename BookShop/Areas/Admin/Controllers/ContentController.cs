using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.UI.WebControls;
using Model.EF;

namespace BookShop.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ContentDao();
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
            var content = new ContentDao().ViewDetail(id);
            return View(content);
        }

        [HttpPost]
        public ActionResult Create(Content content)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();
                long id = dao.Insert(content);
                if (id > 0)
                {
                    setAlert("Thêm mới thành công", "success");
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Không thêm được");
                }

            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(Content content)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();
                var result = dao.Update(content);
                if (result)
                {
                    setAlert("Cập nhật tin tức thành công", "success");
                    return RedirectToAction("Index", "Content");
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
            new ContentDao().Delete(id);
            return RedirectToAction("Index");
        }
        //
        // GET: /Admin/Content/
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    SetViewBag();
        //    return View();
        //}
        //[HttpGet]
        //public ActionResult Edit(long id)
        //{
        //    var dao = new ContentDao();
        //    var content = dao.GetByID(id);
        //    SetViewBag(content.CategoryID);
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Edit(Content model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //    SetViewBag(model.CategoryID);
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(Content model )
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //    SetViewBag();
        //    return View();
        //}
        //public void SetViewBag(long? selectedID=null)
        //{
        //    var dao = new CategoryDao();
        //    ViewBag.CategoryID = new SelectList(dao.ListAll(),"ID","Name",selectedID);
        //}
	}
}