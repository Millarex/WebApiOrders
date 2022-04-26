
namespace WebApiOrders.Domain.Data
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}
