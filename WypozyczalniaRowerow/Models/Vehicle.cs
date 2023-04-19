namespace WypozyczalniaRowerow.Models;
using System.ComponentModel.DataAnnotations;
public class Vehicle
{
    [Key]
    [Display(Name = "ID")]
    public int Id { get; set; }
    
    [Required]
    [StringLength(32)]
    [Display(Name = "Marka")]
    public string Brand { get; set; }
    
    [StringLength(16)]
    [Display(Name = "Kolor")]
    public string? Color { get; set; }
    
    [StringLength(32)] 
    [Display(Name = "Przeznaczenie")]
    public string? IntendedTarget { get; set; }
    
    [StringLength(256)]
    [Display(Name = "Opis")]
    public string? Description { get; set; }
    
    [Url]
    [Display(Name = "URL zdjęcia")]
    public string? PictureHref { get; set; }
    
    
    [Required]
    [Display(Name = "ID typu pojazdu")]
    public int VehicleTypeId { get; set; }
    [Display(Name = "Typ pojazdu")]
    public VehicleType? Type { get; set; }
    
    [Required]
    [Display(Name = "ID punktu wypożyczeń")]
    public int RentingLocationId { get; set; }
    [Display(Name = "Punkt wypożyczeń")]
    public RentingLocation? RentingLocation { get; set; }
}