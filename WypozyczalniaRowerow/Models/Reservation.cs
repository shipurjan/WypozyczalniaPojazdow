namespace WypozyczalniaRowerow.Models;

public class Reservation
{
    public int Id { get; set; }
    public DateTime? ReservationDate { get; set; }
    public RentingLocation RentingLocation { get; set; }
    public string? ClientName { get; set; }
    public Vehicle? ReservedVehicle { get; set; }
}