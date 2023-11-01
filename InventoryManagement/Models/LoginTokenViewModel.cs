namespace InventoryManagement.Models
{
    public class LoginTokenViewModel
    {
        public int Id { get; set; }
        public Guid Token { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
