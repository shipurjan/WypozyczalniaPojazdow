namespace WypozyczalniaRowerow.DTO;

public class VehicleDto
{
    public int Id { get; set; }
    public string? Brand { get; set; }
    public string? Color { get; set; }
    public string? IntendedTarget { get; set; }
    public string? Description { get; set; }
    public string? PictureHref { get; set; }
    public VehicleTypeDto Type { get; set; }
    public RentingLocationDto RentingLocation { get; set; }
}