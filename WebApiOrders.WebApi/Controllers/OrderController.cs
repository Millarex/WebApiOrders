using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiOrders.Application.Interfaces;
using WebApiOrders.Domain.Data;

namespace WebApiOrders.WebApi.Controllers
{
    [Route("api/entity/[controller]")]
    public class OrderController : GenericBaseController<OrderModel>
    {
        public OrderController(IGenericRepository<OrderModel> repository) : base(repository)
        {
        }
    }
}
