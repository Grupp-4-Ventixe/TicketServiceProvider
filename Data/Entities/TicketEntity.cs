

using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class TicketEntity
{
    [Key]
    public int Id { get; set; }
    public string BookingId { get; set; } = null!;
    public string EventId { get; set; } = null!;
    public string InvoiceId { get; set; } = null!;  
    public string SeatNumber { get; set; } = null!;
    public string Gate { get; set; } = null!;    
    public string Category { get; set; } = null!;
}
