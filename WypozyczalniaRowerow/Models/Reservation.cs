namespace WypozyczalniaRowerow.Models;

public class Reservation
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string ClientName { get; set; }
}