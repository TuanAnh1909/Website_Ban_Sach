using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.Dao;
using PagedList;

namespace Model.Dao
{
    public class AuthorDao
    {
        
        BookShopOnlDbContext db=null;
    public AuthorDao()
    {
        db = new BookShopOnlDbContext();
    }
        public long Insert(Author entity)
        {
            db.Authors.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Author entity)
        {
            try
            {
                var author = db.Authors.Find(entity.ID);
                author.Name = entity.Name;
                author.Phone = entity.Phone;
                author.Address = entity.Address;
                author.Email = entity.Email;
                author.CreateDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
            
        }
        public IEnumerable<Author> ListAllpaging(String searchString, int page, int pageSize)
        {
            IQueryable<Author> model = db.Authors;
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
        
       
        public bool Delete(int id)
        {
            try
            {
                var author = db.Authors.Find(id);
                db.Authors.Remove(author);
                db.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
            
        }
        public List<Author> ListByID()
        {
            return db.Authors.Where(x => x.status == true).ToList();
        }
        public Author ViewDetail(long id)
        {
            return db.Authors.Find(id);
        }
    }
}
