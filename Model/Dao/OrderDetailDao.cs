using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class OrderDetailDao
    {
        BookShopOnlDbContext db=null;
        public OrderDetailDao()
        {
        db=new BookShopOnlDbContext();
    }
        public bool Insert(OrderDetail orderdetail)
        {
            try
            {
                db.OrderDetails.Add(orderdetail);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
