using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
    public class ContentDao
    {
        BookShopOnlDbContext db = null;
    public ContentDao()
    {
        db = new BookShopOnlDbContext();
    }
    public Content GetByID(long id)
    {
        return db.Contents.Find(id);
    }
    public long Insert(Content entity)
    {
        db.Contents.Add(entity);
        db.SaveChanges();
        return entity.ID;
    }
    public bool Update(Content entity)
    {
        try
        {
            var content = db.Contents.Find(entity.ID);
            content.Name = entity.Name;
            content.MetaTitle = entity.MetaTitle;
            content.Discriptions = entity.Discriptions;
            content.Images = entity.Images;
            content.Detail = entity.Detail;
            content.CreateDate = DateTime.Now;
            content.ModifiedDate = DateTime.Now;
            content.ModifiedBy = entity.ModifiedBy;
            content.status = entity.status;
            db.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }
    public IEnumerable<Content> ListAllpaging(String searchString, int page, int pageSize)
    {
        IQueryable<Content> model = db.Contents;
        if (!string.IsNullOrEmpty(searchString))
        {
            model = model.Where(x => x.Name.Contains(searchString) || x.Discriptions.Contains(searchString));
        }
        return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
    }
    //public User GetByID(String UserName)
    //{
    //    return db.Users.SingleOrDefault(x => x.UserName==UserName);
    //}
    public Content ViewDetail(long id)
    {
        return db.Contents.Find(id);
    }

    public bool Delete(int id)
    {
        try
        {
            var content = db.Contents.Find(id);
            db.Contents.Remove(content);
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
