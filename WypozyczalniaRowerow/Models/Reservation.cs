namespace WypozyczalniaRowerow.Models;

public class Reservation
{
    public int Id { get; set; }
    public DateTime? ReservationDate { get; set; }
    public string? ClientName { get; set; }
    
    
    public int RentingLocationId { get; set; }
    public RentingLocation RentingLocation { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
}