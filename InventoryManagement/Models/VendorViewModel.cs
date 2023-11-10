using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class VendorViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public string Name { get; set; }
        [Required]  
        public string Email { get; set; }
        [Required]  
        public string PhoneNo1 { get; set; }
        public string PhoneNo2 { get; set; }
        public string Address { get; set; }
        [Required]  
        public string PAnNo { get; set; }
        public string GstNo { get; set; }
        [Required]  
        public string ReportVendor { get; set; }
        [Required]  
        public string Company { get; set; }
        [Required]  
        public string VendorType { get; set; }
        public string Description { get; set; }
    }
}
