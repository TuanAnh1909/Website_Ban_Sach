using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;


namespace Model.Dao
{
    

    public class UserDao
    {
        BookShopOnlDbContext db = null;
    public UserDao()
    {
        db = new BookShopOnlDbContext();
    }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        //
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Name = entity.Name;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public IEnumerable<User> ListAllpaging(string searchString,int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x=>x.CreateDate).ToPagedList(page,pageSize);
        }
        //
        public User GetByID(String UserName)
        {
            return db.Users.SingleOrDefault(x => x.UserName==UserName);
        }
        //
        public User ViewDetail(long id)
        {
            return db.Users.Find(id);
        }
        //
        public int Login(String UserName, String Password)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == UserName);
            if (result==null)
            {
                return 0;
            }
            else
            {
                if (result.status == false)
                    return -1;
                else
                {
                    if(result.Password==Password)
                    {
                        return 1;
                    }
                    else
                    return -2;
                }
            }
        }
        //
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
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
