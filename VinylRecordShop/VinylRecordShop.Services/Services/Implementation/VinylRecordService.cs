using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VinylRecodShop.Model.Database.DatabaseContext;

namespace VinylRecordShop.Services.Services.Implementation
{
    public class VinylRecordService : ServiceBase<VinylRecord>
    {
        public override List<VinylRecord> GetAll()
        {
            return GetQuery()
                .Include(vr => vr.Author)
                .Include(vr => vr.Genre)
                .Include(vr => vr.Publisher)
                .ToList();
        }
    }
}
