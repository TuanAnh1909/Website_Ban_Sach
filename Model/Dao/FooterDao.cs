using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class FooterDao
    {
        BookShopOnlDbContext db = null;
        public FooterDao()
        {
            db = new BookShopOnlDbContext();
        }
        
    public Footer GetByID(long id)
    {
        return db.Footers.Find(id);
    }
    public string Insert(Footer entity)
    {
        db.Footers.Add(entity);
        db.SaveChanges();
        return entity.ID;
    }
    public bool Update(Footer entity)
    {
        try
        {
            var footer = db.Footers.Find(entity.ID);
            footer.Content = entity.Content;
            footer.status = entity.status;
            
            db.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }
   
    
    public Content ViewDetail(long id)
    {
        return db.Contents.Find(id);
    }

    public bool Delete(int id)
    {
        try
        {
            var footer = db.Footers.Find(id);
            db.Footers.Remove(footer);
            db.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }
        public Footer GetFooter()
        {
            return db.Footers.SingleOrDefault(x => x.status == true);
        }
    }
}
