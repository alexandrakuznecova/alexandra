using System.Windows.Controls;
using VinylRecodShop.Model.Database.DatabaseContext;
using VinylRecordShop.ViewModels.Base;

namespace VinylRecordShop.ViewModels.VinylRecords
{
    public class VinylRecordLightViewModel : EntityViewModel<VinylRecord>
    {
        public VinylRecordLightViewModel(VinylRecord record) : base(record)
        {
        }

        public string Name => Entity.Name;

        public int Id => Entity.Id;
        protected override Page GetListPage()
        {
            return null;
        }

        protected override void CheckProperties()
        {
            //
        }

        protected override string Validate(string fieldName)
        {
            return null;
        }
    }
}
