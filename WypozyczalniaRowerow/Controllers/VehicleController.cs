using Microsoft.AspNetCore.Mvc;
using WypozyczalniaRowerow.Models;
using System.Collections.Generic;
using WypozyczalniaRowerow.Data;
using WypozyczalniaRowerow.Services.VehicleService;

namespace WypozyczalniaRowerow.Controllers;

public class VehicleController : Controller
{
    /*
    private List<Vehicle> vehicles = new List<Vehicle>()
    {
        new Vehicle { Id = 1, Brand = "INDIANA", Type = "Miejski", IntendedUse = "Damski", Color = "Czarny", PictureHref = "/img/indiana.jpg"},
        new Vehicle { Id = 2, Brand = "WHISTLE", Type = "Szosowy", IntendedUse = "Męski", Color = "Biały", PictureHref = "/img/whistle.jpg"},
        new Vehicle { Id = 3, Brand = "ATALA", Type = "MTB", IntendedUse = "Męski", Color = "Srebrny", PictureHref = "/img/atala.jpg"},
    };
    */

    private readonly IVehicleService _vehicleService;

    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }
    
    [HttpGet]
    public IActionResult List()
    {
        var vehicles = _vehicleService.GetAll().ToList();
        return View(vehicles);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Vehicle vehicle)
    {
        _vehicleService.Add(vehicle);
        _vehicleService.Save();
        
        return View();
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var vehicle = _vehicleService.Get(id);
        return View(vehicle);
    }

    [HttpPost]
    public IActionResult Delete(Vehicle vehicle)
    {
        _vehicleService.Delete(vehicle);
        _vehicleService.Save();
        return View();
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var vehicle = _vehicleService.Get(id);
        return View(vehicle);
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var vehicle = _vehicleService.Get(id);
        return View(vehicle);
    }
    
    
    [HttpPost]
    public IActionResult Edit(Vehicle vehicle)
    {
        _vehicleService.Edit(vehicle);
        _vehicleService.Save();
        return View();
    }
}