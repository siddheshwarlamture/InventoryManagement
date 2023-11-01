using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class UsersViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Salt { get; set; }
        [Required]
        public string Password { get; set; }

        public string Phone { get; set; }
        [Required]
        public static List<SelectListItem> GenderList { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set;}
        public static void getGenderList()
        {
            GenderList = new List<SelectListItem>();
            GenderList.Add(new SelectListItem { Text = "Male", Value = "1" });
            GenderList.Add(new SelectListItem { Text = "Female", Value = "2" });
        }
    }
}
