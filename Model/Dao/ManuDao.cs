using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ManuDao
    {
        BookShopOnlDbContext db = null;
    public ManuDao()
    {
        db = new BookShopOnlDbContext();
    }
    public List<Manu> ListByGroupID(int groupID)
    {
        return db.Manus.Where(x => x.TypeID == groupID && x.status==true).OrderBy(x=>x.DisplayOder).ToList();
    }
    }
}
