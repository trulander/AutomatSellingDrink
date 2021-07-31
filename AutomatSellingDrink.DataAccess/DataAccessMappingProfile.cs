using AutoMapper;

namespace AutomatSellingDrink.DataAccess
{
    public class DataAccessMappingProfile: Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<Core.Models.Coin, Entities.Coin>().ReverseMap();
            CreateMap<Core.Models.Drink, Entities.Drink>().ReverseMap();
            CreateMap<Core.Models.File, Entities.File>().ReverseMap();
            CreateMap<Core.Models.Settings, Entities.Settings>().ReverseMap();
            CreateMap<Core.Models.Balance, Entities.Balance>().ReverseMap();
        }
    }
}