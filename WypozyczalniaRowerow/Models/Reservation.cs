using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace WypozyczalniaRowerow.Models;

public class DateValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        // Funkcja walidująca
        // dane są poprawne, gdy data (DateTime)
        // jest późniejsza niż data dzisiejsza o północy (DateTime.Today)
        
        DateTime todayDate = Convert.ToDateTime(value);
        return todayDate >= DateTime.Today;
    }
}

public class Reservation
{
    [Key]
    [Display(Name = "ID")]
    public int Id { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    [DateValidation(ErrorMessage = "Nie można wprowadzić rezerwacji na przeszły termin")]
    [Display(Name = "Data rezerwacji")]
    public DateTime ReservationDate { get; set; }
    
    [Required]
    [StringLength(32)]
    [Display(Name = "Imię klienta")]
    public string ClientName { get; set; }
    
    
    [Required]
    [Display(Name = "ID punktu wypożyczeń")]
    public int RentingLocationId { get; set; }
    [Display(Name = "Punkt wypożyczeń")]
    public RentingLocation? RentingLocation { get; set; }
    
    [Required]
    [Display(Name = "ID pojazdu")]
    public int VehicleId { get; set; }
    [Display(Name = "Pojazd")]
    public Vehicle? Vehicle { get; set; }
}