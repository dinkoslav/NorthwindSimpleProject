namespace Fourth.WebAPI.App_Start.AutomapperProfiles
{
    using AutoMapper;
    using Fourth.Database;
    using Fourth.Services.ViewModels.Models;

    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            this.CreateMap<Customer, CustomerGridModel>()
                .ForMember(sd => sd.Id, opt => opt.MapFrom(src => src.CustomerID))
                .ForMember(sd => sd.Name, opt => opt.MapFrom(src => src.CompanyName))
                .ForMember(sd => sd.OrdersCount, opt => opt.MapFrom(src => src.Orders.Count));

            this.CreateMap<Customer, CustomerModel>();
        }
    }
}