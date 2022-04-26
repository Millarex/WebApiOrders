using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiOrders.Application.Interfaces;
using WebApiOrders.Domain.Data;

namespace WebApiOrders.WebApi.Controllers
{
    [Route("api/entity/[controller]")]
    public class UserController : GenericBaseController<UserModel>
    {
        public UserController(IGenericRepository<UserModel> repository) : base(repository)
        {
        }
    }
}
