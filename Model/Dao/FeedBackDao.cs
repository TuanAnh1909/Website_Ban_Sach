using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class FeedBackDao
    {
        BookShopOnlDbContext db=null;
    public FeedBackDao()
    {
        db = new BookShopOnlDbContext();
    }
        public long Insert(FeedBack entity)
        {
            db.FeedBacks.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(FeedBack entity)
        {
            try
            {
                var feedback = db.FeedBacks.Find(entity.ID);
                feedback.Name = entity.Name;
                feedback.Phone = entity.Phone;
                feedback.Address = entity.Address;
                feedback.Email = entity.Email;
                feedback.CreateDate = DateTime.Now;
                feedback.Content = entity.Content;

                db.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
            
        }
        public IEnumerable<FeedBack> ListAllpaging(String searchString, int page, int pageSize)
        {
            IQueryable<FeedBack> model = db.FeedBacks;
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
        public FeedBack ViewDetail(long id)
        {
            return db.FeedBacks.Find(id);
        }
       
        public bool Delete(int id)
        {
            try
            {
                var feedback = db.FeedBacks.Find(id);
                db.FeedBacks.Remove(feedback);
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
