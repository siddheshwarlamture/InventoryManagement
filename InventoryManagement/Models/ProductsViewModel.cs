using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models
{
    public class ProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int UnitsId { get; set; }

        [ValidateNever]
        [NotMapped]
        public IEnumerable<SelectListItem> UnitsList { get; set; }

    }
}
