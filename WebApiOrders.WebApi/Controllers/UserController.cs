using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiOrders.Application.Interfaces;
using WebApiOrders.Domain.Data;
using WebApiOrders.WebApi.Models;

namespace WebApiOrders.WebApi.Controllers
{
    [Route("api/entity/[controller]")]
    public class UserController : GenericBaseController<UserModel, UserDto>
    {
        public UserController(IAsyncGenericRepository<UserModel> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
