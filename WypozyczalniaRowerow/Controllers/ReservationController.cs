using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WypozyczalniaRowerow.Models;
using WypozyczalniaRowerow.Services.ReservationService;

namespace WypozyczalniaRowerow.Controllers;

public class ReservationController : Controller
{
    private readonly IMapper _mapper;
    private readonly IReservationService _service;

    public ReservationController(IReservationService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult List()
    {
        var reservations = _service.GetAll().ToList();
        return View(_mapper.Map<List<Reservation>>(reservations));
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Reservation reservation)
    {
        if (ModelState.IsValid)
        {
            _service.Add(_mapper.Map<Reservation>(reservation));
            _service.Save();
            return RedirectToAction(nameof(List));
        }

        return View();
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var reservation = _service.GetById(id);
        return View(_mapper.Map<Reservation>(reservation));
    }

    [HttpPost]
    public IActionResult Delete(Reservation reservation)
    {
        _service.Delete(_mapper.Map<Reservation>(reservation));
        _service.Save();
        return RedirectToAction(nameof(List));
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var reservation = _service.GetById(id);
        return View(_mapper.Map<Reservation>(reservation));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var reservation = _service.GetById(id);
        return View(_mapper.Map<Reservation>(reservation));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Reservation reservation)
    {
        if (ModelState.IsValid)
        {
            _service.Edit(_mapper.Map<Reservation>(reservation));
            _service.Save();
            return RedirectToAction(nameof(List));
        }

        return View();
    }
}