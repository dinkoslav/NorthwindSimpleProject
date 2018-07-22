namespace Fourth.WebAPI.App_Start.AutomapperProfiles
{
    using AutoMapper;
    using Database;
    using Services.ViewModels.Models;
    using System.Linq;

    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            this.CreateMap<Order, OrderModel>()
                .ForMember(sd => sd.Products, opt => opt.MapFrom(src => src.Order_Details));

            this.CreateMap<Order_Detail, OrderProductModel>()
                .ForMember(sd => sd.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(sd => sd.OrderUnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(sd => sd.OrderQuantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(sd => sd.OrderUnitDiscount, opt => opt.MapFrom(src => src.Discount))
                .ForMember(sd => sd.Discontinued, opt => opt.MapFrom(src => src.Product.Discontinued))
                .ForMember(sd => sd.UnitsInStock, opt => opt.MapFrom(src => src.Product.UnitsInStock))
                .ForMember(sd => sd.UnitsOnOrder, opt => opt.MapFrom(src => src.Product.UnitsOnOrder));
        }
    }
}