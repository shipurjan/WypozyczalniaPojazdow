using System;
using System.Linq;
using System.Linq.Expressions;
using WypozyczalniaRowerow.Data;
using WypozyczalniaRowerow.Models;

namespace WypozyczalniaRowerow.Services.VehicleTypeService;

public class VehicleTypeService : RepositoryService<VehicleType>, IVehicleTypeService
{
    public VehicleTypeService(ApplicationDbContext context) : base(context)
    {
    }
}