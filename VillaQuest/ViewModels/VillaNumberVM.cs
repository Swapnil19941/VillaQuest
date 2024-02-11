using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using VillaQuest.Domain.Entities;

namespace VillaQuest.ViewModels
{
    public class VillaNumberVM
    {
        public VillaNumber? VillaNumber { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> Villas { get; set; }
    }
}
