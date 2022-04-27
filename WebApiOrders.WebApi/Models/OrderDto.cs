using AutoMapper;
using WebApiOrders.Application.Common.Mapping;
using WebApiOrders.Application.Interfaces;
using WebApiOrders.Domain.Data;

namespace WebApiOrders.WebApi.Models
{
    public class OrderDto : IMapWith<OrderModel>, IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderDto, OrderModel>();
        }
    }
}
