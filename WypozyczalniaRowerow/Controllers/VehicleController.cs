using Microsoft.AspNetCore.Mvc;
using WypozyczalniaRowerow.Models;
using System.Collections.Generic;

namespace WypozyczalniaRowerow.Controllers;

public class VehicleController : Controller
{
    private List<Vehicle> vehicles = new List<Vehicle>()
    {
        new Vehicle { Id = 1, Brand = "INDIANA", Type = "Miejski", IntendedUse = "Damski", Color = "Czarny", PictureHref = "/img/indiana.jpg"},
        new Vehicle { Id = 2, Brand = "WHISTLE", Type = "Szosowy", IntendedUse = "Męski", Color = "Biały", PictureHref = "/img/whistle.jpg"},
        new Vehicle { Id = 3, Brand = "ATALA", Type = "MTB", IntendedUse = "Męski", Color = "Srebrny", PictureHref = "/img/atala.jpg"},
    };
        
    public IActionResult List()
    {
        return View(vehicles);
    }

    public IActionResult Details(Vehicle vehicle)
    {
        return View(vehicle);
    }
}