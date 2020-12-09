using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class BookCategoryDao
    {
        BookShopOnlDbContext db = null;
        public BookCategoryDao()
        {
            db = new BookShopOnlDbContext();
        }
        public List<BookCategory> ListAll()
        {
            return db.BookCategories.Where(x => x.status == true).ToList();
        }

        public long Insert(BookCategory entity)
        {
            db.BookCategories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(BookCategory entity)
        {
            try
            {
                var cate = db.BookCategories.Find(entity.ID);
                cate.Name = entity.Name;
                cate.MetaTitle = entity.MetaTitle;
                cate.CreateDate = entity.CreateDate;
                //cate.CreateBy = entity.CreateBy;
                cate.status = entity.status;
                cate.ShowOnHome = entity.ShowOnHome;
                db.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
            
        }
        public IEnumerable<BookCategory> ListAllpaging(String searchString, int page, int pageSize)
        {
            IQueryable<BookCategory> model = db.BookCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        //public User GetByID(String UserName)
        //{
        //    return db.Users.SingleOrDefault(x => x.UserName==UserName);
        //}
        
       
        public bool Delete(int id)
        {
            try
            {
                var category = db.BookCategories.Find(id);
                db.BookCategories.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
            
        }
        public BookCategory ViewDetail(long id)
        {
            return db.BookCategories.Find(id);
        }
       

        
    }
}
