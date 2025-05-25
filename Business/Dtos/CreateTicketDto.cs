

namespace Business.Dtos;

public class CreateTicketDto
{
    public string SeatNumber { get; set; } = null!;
    public string Gate { get; set; } = null!;
    public string Category { get; set; } = null!;
}
