using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiOrders.Application.Interfaces;
using WebApiOrders.Domain.Data;
using WebApiOrders.WebApi.Models;

namespace WebApiOrders.WebApi.Controllers
{
    [Route("api/entity/[controller]")]
    public class OrderController : GenericBaseController<OrderModel, OrderDto>
    {
        public OrderController(IAsyncGenericRepository<OrderModel> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
