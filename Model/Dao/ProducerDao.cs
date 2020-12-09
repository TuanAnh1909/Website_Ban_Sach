using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class ProducerDao
    {
        BookShopOnlDbContext db=null;
    public ProducerDao()
    {
        db = new BookShopOnlDbContext();
    }
        public long Insert(Producer entity)
        {
            db.Producers.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Producer entity)
        {
            try
            {
                var producer = db.Producers.Find(entity.ID);
                producer.Name = entity.Name;
                producer.Phone = entity.Phone;
                producer.Address = entity.Address;
                producer.Email = entity.Email;
                producer.CreateDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
            
        }
        public List<Producer> ListAll()
        {
            return db.Producers.Where(x => x.status == true).ToList();
        }
        public IEnumerable<Producer> ListAllpaging(String searchString, int page, int pageSize)
        {
            IQueryable<Producer> model = db.Producers;
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
        public Producer ViewDetail(long id)
        {
            return db.Producers.Find(id);
        }
       
        public bool Delete(long id)
        {
            try
            {
                var producer = db.Producers.Find(id);
                db.Producers.Remove(producer);
                db.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
            
        }
        public List<Producer> ListByID()
        {
            return db.Producers.Where(x => x.status == true).ToList();
        }
    }
}
