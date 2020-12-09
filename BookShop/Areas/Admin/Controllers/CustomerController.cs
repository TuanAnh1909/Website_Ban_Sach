using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        //
        // GET: /Admin/Customer/
        
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new CustomerDao();
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
            var customer = new CustomerDao().ViewDetail(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                long id = dao.Insert(customer);
                if (id > 0)
                {
                    setAlert("Thêm mới khách hàng thành công", "success");
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ModelState.AddModelError("", "Không thêm được");
                }

            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                var result = dao.Update(customer);
                if (result)
                {
                    setAlert("Cập nhật thông tin khách hàng thành công", "success");
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ModelState.AddModelError("", "Không sửa  được");
                }

            }
            return View("Index");


        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CustomerDao().Delete(id);
            return RedirectToAction("Index");
        }
	}
}