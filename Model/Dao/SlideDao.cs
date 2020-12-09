using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class SlideDao
    {
        BookShopOnlDbContext db = null;
        public SlideDao()
        {
            db = new BookShopOnlDbContext();
        }
        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.status == true).OrderBy(x => x.DisplayOder).ToList();

        }
    }
}
