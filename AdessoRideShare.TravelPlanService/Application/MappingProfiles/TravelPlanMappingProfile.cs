using AutoMapper;
using AdessoRideShare.TravelPlanService.Application.DTOs;
using AdessoRideShare.TravelPlanService.Domain.Entities;

namespace AdessoRideShare.TravelPlanService.Application.MappingProfiles
{
    public class TravelPlanMappingProfile : Profile
    {
        public TravelPlanMappingProfile()
        {
            CreateMap<TravelPlan, TravelPlanDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DestinationLocation, opt => opt.MapFrom(src => src.DestinationLocation))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.AvailableSeats, opt => opt.MapFrom(src => src.AvailableSeats));

            CreateMap<Location, LocationDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude));
        }
    }
}
