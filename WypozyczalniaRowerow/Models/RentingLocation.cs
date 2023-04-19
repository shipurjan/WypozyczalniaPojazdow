using System.ComponentModel.DataAnnotations;

namespace WypozyczalniaRowerow.Models;

public class RentingLocation
{
    [Key]
    [Display(Name = "ID")]
    public int Id { get; set; }
    
    [Required]
    [StringLength(64)]
    [Display(Name = "Miasto")]
    public string City { get; set; }
    
    [Required]
    [StringLength(64)]
    [Display(Name = "Ulica")]
    public string Street { get; set; }
    
    
    [Display(Name = "Dostępne pojazdy")]
    public List<Vehicle>? AvailableVehicles { get; set; }
}