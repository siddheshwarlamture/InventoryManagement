using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Models;

namespace InventoryManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<InventoryManagement.Models.UsersViewModel> User { get; set; } = default!;

        public DbSet<InventoryManagement.Models.VendorViewModel> Vendors { get; set; } = default!;

        public DbSet<InventoryManagement.Models.ApplicationUserViewModel> ApplicationUsers { get; set; }

        public DbSet<InventoryManagement.Models.CompanyViewModel> CompanyViewModel { get; set; } = default!;

        public DbSet<UnitsViewModel> Units { get; set; } = default!;

        public DbSet<ProductsViewModel> Products { get; set; } = default!;
    }
}
