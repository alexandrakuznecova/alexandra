using System.ComponentModel.DataAnnotations;

namespace VinylRecordShop.Logic.Enums
{
    public enum VinylType
    {
        [Display(Name = "Долгоиграющая(Lp)")]
        Lp = 0,

        [Display(Name = "Маленькая(Sp)")]
        Sp = 1
    }
}