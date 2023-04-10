namespace WypozyczalniaRowerow.Models;
using System.ComponentModel.DataAnnotations;
public class Vehicle
{
    [Key]
    public int Id { get; set; }
    public VehicleType? Type { get; set; }
    public string? Brand { get; set; }
    public string? Color { get; set; }
    public string? IntendedTarget { get; set; }
    public string? Description { get; set; }
    public string? PictureHref { get; set; }
}