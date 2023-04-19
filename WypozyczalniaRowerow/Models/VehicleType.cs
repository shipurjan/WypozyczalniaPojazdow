using System.ComponentModel.DataAnnotations;

namespace WypozyczalniaRowerow.Models;

public class VehicleType
{
    [Key]
    [Display(Name = "ID")]
    public int Id { get; set; }
    
    [Required]
    [StringLength(32)]
    [Display(Name = "Nazwa")]
    public string Name { get; set; }
    
    
    [Display(Name = "Pojazdy")]
    public List<Vehicle>? Vehicles { get; set; }
}