using System.Collections.Generic;


namespace WebApiOrders.Domain.Data
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int RoleId { get; set; }
        public List<OrderModel> Orders { get; set; }
        public RoleModel Role { get; set; }

    }
}
