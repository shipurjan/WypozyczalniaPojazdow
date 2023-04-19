using AutoMapper;
using WypozyczalniaRowerow.Models;
using WypozyczalniaRowerow.DTO;
namespace WypozyczalniaRowerow.Profiles;

public class RentingSystemProfile : Profile
{
    public RentingSystemProfile()
    {
        CreateMap<Vehicle, VehicleDto>();
        CreateMap<VehicleType, VehicleTypeDto>();
        CreateMap<RentingLocation, RentingLocationDto>();
        CreateMap<Reservation, ReservationDto>();
    }
}