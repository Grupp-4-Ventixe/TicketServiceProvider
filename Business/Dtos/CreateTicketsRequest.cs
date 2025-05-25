

namespace Business.Dtos;

public class CreateTicketsRequest
{
    public string InvoiceId { get; set; } = null!;
    public string EventId { get; set; } = null!;
    public string BookingId { get; set; } = null!;
    public List<CreateTicketDto> Tickets { get; set; } = new List<CreateTicketDto>();
}
