using BookShop.Models;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BookShop.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";// key này là 1 hằng số, ko thể thay đổi
        //
        // GET: /Cart/
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null) //kiểm tra giỏ hàng đã có sp
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(long bookId, int quantity)
        {
            var book = new BookDao().ViewDetail(bookId);
            var cart = Session[CartSession]; //kiểm tra key của session
            if (cart != null)// đã có key
            {
                var list=(List<CartItem>)cart;  //ép kiểu của Cart
                if (list.Exists(x => x.Book.ID == bookId)) // th giỏ hàng đã có sách vừa chọn
                {
                    foreach(var item in list)
                {
                    if (item.Book.ID == bookId)
                    {
                        item.Quantity+=quantity;
                    }
                }
                }
                else // nếu chưa có, thì add mới sách vào list
                {
                    //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Quantity = quantity;
                item.Book = book;
                list.Add(item);
                }
                //gán vào session
                Session[CartSession] = list;
                
            }
            
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Quantity = quantity;
                item.Book = book;

                var list=new List<CartItem>();
                list.Add(item);
                //gán dl vào session
                Session[CartSession] = list;
                
                
            }
            return RedirectToAction("Index");
        }
        
        
        public JsonResult Delete(long id)//id lấy ở ajax truyền lên
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Book.ID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(String cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];
           
                foreach (var item in sessionCart)
                {
                    var jsonItem = jsonCart.SingleOrDefault(x => x.Book.ID == item.Book.ID);
                    if (jsonItem != null)
                    {
                        item.Quantity = jsonItem.Quantity;
                    }
                }
                Session[CartSession] = sessionCart;//cập nhật lại cart
            

            return Json(new
            {
                status = true
            });
        }
        
        [HttpGet]
        public ActionResult Payment()
        {

            var cart = Session[CartSession];

            var list = new List<CartItem>();
            ViewBag.ngaymua = DateTime.Now;
            int tien = 0;
            if (cart != null)
            {
                list = (List<CartItem>)cart;
                foreach (var item in list)
                {
                    tien += Convert.ToInt32(item.Book.Price.GetValueOrDefault(0) * item.Quantity);
                }
                ViewBag.tongtien = tien;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string shipname, string mobile, string address, string email)
        {
            var order = new Order();
            order.CreateDate = DateTime.Now;
            order.ShipAddress = address;
            order.ShipPhone = mobile;
            order.ShipName = shipname;
            order.ShipEmail = email;
            try {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                foreach (var item in cart)
                {
                    var orderdetail = new OrderDetail();
                    orderdetail.BookID = item.Book.ID;
                    orderdetail.OrderID = id;
                    orderdetail.Price = item.Book.Price;
                    orderdetail.Quantity = item.Quantity;
                }
            }
            catch (Exception)
            {
                //mua hang ko thanh cong

                return Redirect("/loi-mua-hang");
            }
            
            return Redirect("/hoan-thanh");
        }
        public ActionResult Success()
        {
            return View();
        }
	}
}