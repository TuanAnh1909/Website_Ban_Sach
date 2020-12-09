using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.Dao
{
    public class OrderDao
    {
        BookShopOnlDbContext db=null;
        public OrderDao()
        {
        db=new BookShopOnlDbContext();
    }
        public long Insert(Order order)
        {
                db.Orders.Add(order);
                db.SaveChanges();
                return order.ID;
           
        }
    }
}
