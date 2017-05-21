using System.Linq;
using VinylRecodShop.Model.Database.DatabaseContext;

namespace VinylRecordShop.Services.Services.Implementation
{
    public class GenreService : ServiceBase<Genre>
    {
        public override bool CanDelete(int id)
        {
            bool canDelete = !EntityContext.VinylRecords.Any(vr => vr.GenreId == id);
            return base.CanDelete(id) && canDelete;
        }
    }
}
