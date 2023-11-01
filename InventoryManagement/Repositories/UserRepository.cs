
using InventoryManagement.Data;
using InventoryManagement.Models;

namespace InventoryManagement.Repositories
{
    public interface IUserRepository
    {
        public void Create(UsersViewModel users);
    }
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _userContext;

        public UserRepository(ApplicationDbContext userContext)
        {
            _userContext = userContext;
        }
        public void Create(UsersViewModel users)
        {
            _userContext.Add(users);
            _userContext.SaveChanges();
        }
    }
}
