namespace WypozyczalniaRowerow.Models;
using System.ComponentModel.DataAnnotations;
public class VehicleViewModel
{
    [Key]
    public int Id { get; set; }
    public string? Brand { get; set; }
    public string? Type { get; set; }
    public string? Color { get; set; }
    public string? IntendedUse { get; set; }
    public string? PictureHref { get; set; }
}