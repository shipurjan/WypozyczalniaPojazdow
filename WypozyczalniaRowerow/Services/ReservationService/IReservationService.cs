using System;
using System.Linq;
using System.Linq.Expressions;
using WypozyczalniaRowerow.Models;

namespace WypozyczalniaRowerow.Services.ReservationService;

public interface IReservationService : IRepositoryService<Reservation>
{
}