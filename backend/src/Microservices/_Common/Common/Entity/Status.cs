using System.ComponentModel.DataAnnotations;
using TypeGen.Core.TypeAnnotations;

namespace Common.Entity
{
    [ExportTsEnum(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_models")]
    public enum Status
    {
        [Display(Name = "Feldolgozás")]
        Processing = 0,

        [Display(Name = "Összecsomagolás alatt")]
        Packing = 1,

        [Display(Name = "Futár felvételére vár")]
        WaitingToPickup = 2,

        [Display(Name = "Kézbesítés alatt")]
        PickedUp = 3,

        [Display(Name = "Kiszállítva")]
        Delivered = 4,

        [Display(Name = "Visszavont")]
        Cancelled = 5,
    }
}
