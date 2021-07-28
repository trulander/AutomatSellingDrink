using AutoMapper;
using AutomatSellingDrink.API.Contracts;

namespace AutomatSellingDrink.API
{
    public class ApiMappingProfile: Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Core.Models.Coin, Contracts.Coin>().ReverseMap();
            CreateMap<Core.Models.Drink, Contracts.Drink>().ReverseMap();
            CreateMap<Core.Models.File, Contracts.File>().ReverseMap();
            CreateMap<Core.Models.Settings, Contracts.Settings>().ReverseMap();
        }
    }
}