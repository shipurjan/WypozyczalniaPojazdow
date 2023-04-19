using Microsoft.AspNetCore.Mvc;
using WypozyczalniaRowerow.Models;
using System.Collections.Generic;
using AutoMapper;
using WypozyczalniaRowerow.Data;
using WypozyczalniaRowerow.Services.RentingLocationService;

namespace WypozyczalniaRowerow.Controllers;

public class RentingLocationController : Controller
{
    private readonly IRentingLocationService _service;
    private readonly IMapper _mapper;

    public RentingLocationController(IRentingLocationService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IActionResult List()
    {
        var locations = _service.GetAll().ToList();
        return View(_mapper.Map<List<RentingLocation>>(locations));
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(RentingLocation location)
    {
        _service.Add(_mapper.Map<RentingLocation>(location));
        _service.Save();
        
        return View();
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var location = _service.GetById(id);
        return View(_mapper.Map<RentingLocation>(location));
    }

    [HttpPost]
    public IActionResult Delete(RentingLocation location)
    {
        _service.Delete(_mapper.Map<RentingLocation>(location));
        _service.Save();
        return View();
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var location = _service.GetById(id);
        return View(_mapper.Map<RentingLocation>(location));
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var location = _service.GetById(id);
        return View(_mapper.Map<RentingLocation>(location));
    }
    
    
    [HttpPost]
    public IActionResult Edit(RentingLocation location)
    {
        _service.Edit(_mapper.Map<RentingLocation>(location));
        _service.Save();
        return View();
    }
}