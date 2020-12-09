using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class CustomerDao
    {
        
        BookShopOnlDbContext db=null;
    public CustomerDao()
    {
        db = new BookShopOnlDbContext();
    }
        public long Insert(Customer entity)
        {
            db.Customers.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Customer entity)
        {
            try
            {
                var customer = db.Customers.Find(entity.ID);
                customer.Name = entity.Name;
                customer.Phone = entity.Phone;
                customer.Address = entity.Address;
                customer.Email = entity.Email;
                customer.CreateDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
            
        }
        public IEnumerable<Customer> ListAllpaging(String searchString, int page, int pageSize)
        {
            IQueryable<Customer> model = db.Customers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Email.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        //public User GetByID(String UserName)
        //{
        //    return db.Users.SingleOrDefault(x => x.UserName==UserName);
        //}
        public Customer ViewDetail(long id)
        {
            return db.Customers.Find(id);
        }
       
        public bool Delete(int id)
        {
            try
            {
                var customer = db.Customers.Find(id);
                db.Customers.Remove(customer);
                db.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
            
        }
    }
}
