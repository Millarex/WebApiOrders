using AutoMapper;
using WebApiOrders.Application.Common.Mapping;
using WebApiOrders.Application.Interfaces;
using WebApiOrders.Domain.Data;

namespace WebApiOrders.WebApi.Models
{
    public class UserDto : IMapWith<UserModel>, IDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int RoleId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserDto, UserModel>();
        }

    }
}
