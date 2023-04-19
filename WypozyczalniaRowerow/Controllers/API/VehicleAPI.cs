using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WypozyczalniaRowerow.Models;
using WypozyczalniaRowerow.Services.RentingLocationService;
using WypozyczalniaRowerow.Services.VehicleService;

namespace WypozyczalniaRowerow.Controllers.API;

[Route("api/[controller]")]
public class VehicleAPI : Controller
{
    private readonly IVehicleService _service;
    private readonly IMapper _mapper;

    public VehicleAPI(IVehicleService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [HttpGet]
    public string Get()
    {
        var vehicles = _service.GetAll()
            .ToList();
        var mappedVehicles = _mapper.Map<List<Vehicle>>(vehicles);
        return JsonConvert.SerializeObject(mappedVehicles);
    }
    
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return JsonConvert.SerializeObject(_service.GetById(id));
    }
}