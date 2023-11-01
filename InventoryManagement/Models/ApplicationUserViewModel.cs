using Microsoft.AspNetCore.Identity;

namespace InventoryManagement.Models
{
    public class ApplicationUserViewModel: IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; } 
    }
}
