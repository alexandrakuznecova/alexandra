using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using VinylRecordShop.Annotations;
using VinylRecordShop.Logic;

namespace VinylRecordShop.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void Navigate(Page page)
        {
            NavigationHelper.NavigationService.Navigate(page);
        }

        protected void ForceNavigate(Page page = null)
        {
            if (page != null)
            {
                NavigationHelper.NavigationService.Navigate(page);
            }
            else
            {
                NavigationHelper.NavigationService.GoBack();
            }
        }

        protected List<CountryViewModel> GetCountryList()
        {

            return CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Where(ci => !ci.IsNeutralCulture && !ci.CultureTypes.HasFlag(CultureTypes.UserCustomCulture))
                .Select(ci => new RegionInfo(ci.LCID))
                .GroupBy(ri => ri.TwoLetterISORegionName)
                .Select(g => new CountryViewModel
                {
                    Code = g.Key,
                    Name = g.First().DisplayName
                }).ToList();
        }

        protected string GetCountryName(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return "Нет данных";
            }

            var cultureInfo = new CultureInfo(code);
            var ri = new RegionInfo(cultureInfo.Name);
            return ri.DisplayName;
        }
    }
}
