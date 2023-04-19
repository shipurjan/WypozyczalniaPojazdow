namespace WypozyczalniaRowerow.DTO;

public class ReservationDto
{
    public int Id { get; set; }
    public DateTime? ReservationDate { get; set; }
    public string? ClientName { get; set; }
    public VehicleDto Vehicle { get; set; }
    public RentingLocationDto RentingLocation { get; set; }
}