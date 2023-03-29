using Microsoft.AspNetCore.Mvc;
using WypozyczalniaRowerow.Models;
using System.Collections.Generic;

namespace WypozyczalniaRowerow.Controllers;

public class VehicleController : Controller
{
    private List<VehicleViewModel> vehicles = new List<VehicleViewModel>()
    {
        new VehicleViewModel { Id = 1, Brand = "INDIANA", Type = "Miejski", IntendedUse = "Damski", Color = "Czarny", PictureHref = "/img/indiana.jpg"},
        new VehicleViewModel { Id = 2, Brand = "WHISTLE", Type = "Szosowy", IntendedUse = "Męski", Color = "Biały", PictureHref = "/img/whistle.jpg"},
        new VehicleViewModel { Id = 3, Brand = "ATALA", Type = "MTB", IntendedUse = "Męski", Color = "Srebrny", PictureHref = "/img/atala.jpg"},
    };
        
    public IActionResult List()
    {
        return View(vehicles);
    }

    public IActionResult Details(VehicleViewModel vehicle)
    {
        return View(vehicle);
    }
}