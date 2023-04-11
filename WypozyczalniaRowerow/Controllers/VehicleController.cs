using Microsoft.AspNetCore.Mvc;
using WypozyczalniaRowerow.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WypozyczalniaRowerow.Data;
using WypozyczalniaRowerow.Services.VehicleService;

namespace WypozyczalniaRowerow.Controllers;

public class VehicleController : Controller
{
    private readonly IVehicleService _service;

    public VehicleController(IVehicleService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public IActionResult List()
    {
        var vehicles = _service.GetAll()
            .ToList();
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
        _service.Add(vehicle);
        _service.Save();
        
        return View();
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var vehicle = _service.GetById(id);
        return View(vehicle);
    }

    [HttpPost]
    public IActionResult Delete(Vehicle vehicle)
    {
        _service.Delete(vehicle);
        _service.Save();
        return View();
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var vehicle = _service.GetById(id);
        return View(vehicle);
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var vehicle = _service.GetById(id);
        return View(vehicle);
    }
    
    
    [HttpPost]
    public IActionResult Edit(Vehicle vehicle)
    {
        _service.Edit(vehicle);
        _service.Save();
        return View();
    }
}