using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WypozyczalniaRowerow.Models;
using WypozyczalniaRowerow.Services.RentingLocationService;

namespace WypozyczalniaRowerow.Controllers;

public class RentingLocationController : Controller
{
    private readonly IMapper _mapper;
    private readonly IRentingLocationService _service;

    public RentingLocationController(IRentingLocationService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult List()
    {
        var rentingLocations = _service.GetAll().ToList();
        return View(_mapper.Map<List<RentingLocation>>(rentingLocations));
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(RentingLocation rentingLocation)
    {
        _service.Add(_mapper.Map<RentingLocation>(rentingLocation));
        _service.Save();
        return RedirectToAction(nameof(List));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var rentingLocation = _service.GetById(id);
        return View(_mapper.Map<RentingLocation>(rentingLocation));
    }

    [HttpPost]
    public IActionResult Delete(RentingLocation rentingLocation)
    {
        if (ModelState.IsValid)
        {
            _service.Delete(_mapper.Map<RentingLocation>(rentingLocation));
            _service.Save();
            return RedirectToAction(nameof(List));
        }

        return View();
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var rentingLocation = _service.GetById(id);
        return View(_mapper.Map<RentingLocation>(rentingLocation));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var rentingLocation = _service.GetById(id);
        return View(_mapper.Map<RentingLocation>(rentingLocation));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(RentingLocation rentingLocation)
    {
        if (ModelState.IsValid)
        {
            _service.Edit(_mapper.Map<RentingLocation>(rentingLocation));
            _service.Save();
            return RedirectToAction(nameof(List));
        }

        return View();
    }
}