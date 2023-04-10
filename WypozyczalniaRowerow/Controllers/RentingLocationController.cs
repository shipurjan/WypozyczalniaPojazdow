using Microsoft.AspNetCore.Mvc;
using WypozyczalniaRowerow.Models;
using System.Collections.Generic;
using WypozyczalniaRowerow.Data;
using WypozyczalniaRowerow.Services.RentingLocationService;

namespace WypozyczalniaRowerow.Controllers;

public class RentingLocationController : Controller
{
    private readonly IRentingLocationService _service;

    public RentingLocationController(IRentingLocationService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public IActionResult List()
    {
        var locations = _service.GetAll().ToList();
        return View(locations);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(RentingLocation location)
    {
        _service.Add(location);
        _service.Save();
        
        return View();
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var location = _service.GetById(id);
        return View(location);
    }

    [HttpPost]
    public IActionResult Delete(RentingLocation location)
    {
        _service.Delete(location);
        _service.Save();
        return View();
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var location = _service.GetById(id);
        return View(location);
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var location = _service.GetById(id);
        return View(location);
    }
    
    
    [HttpPost]
    public IActionResult Edit(RentingLocation location)
    {
        _service.Edit(location);
        _service.Save();
        return View();
    }
}