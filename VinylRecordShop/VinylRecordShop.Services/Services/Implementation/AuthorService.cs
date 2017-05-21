using System.Linq;
using VinylRecodShop.Model.Database.DatabaseContext;

namespace VinylRecordShop.Services.Services.Implementation
{
    public class AuthorService : ServiceBase<Author>
    {
        public override bool CanDelete(int id)
        {
            bool canDelete = !EntityContext.VinylRecords.Any(vr => vr.AuthorId == id);
            return base.CanDelete(id) && canDelete;
        }
    }
}
