using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using PagedList;

namespace BookShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /Admin/User/
        public ActionResult Index(string searchString,int page = 1, int pageSize = 2)
        {
            var dao = new UserDao();
            var model = dao.ListAllpaging(searchString,page, pageSize);
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
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]

        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
            var dao = new UserDao();
            long id = dao.Insert(user);
            
                if (id > 0)
                {
                    setAlert("Thêm user thành công","success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Không thêm được user");
                }
            }
            return View("Index");
           
        }
        [HttpPost]

        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
            var dao = new UserDao();
            var result = dao.Update(user);
            
                if (result)
                {
                    setAlert("Cập nhật user thành công","success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user không thành công");
                }
            }
            return View("Index");

        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
       
}
}