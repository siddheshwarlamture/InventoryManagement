using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Runtime.Serialization;

namespace InventoryManagement.GenericFiles
{
    public static class ApplicationRoles
    {
        public const string ADMIN = "Admin";
        public const string EMPLOYEE = "Employee";
    }
}
