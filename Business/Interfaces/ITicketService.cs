using Business.Dtos;
using Data.Entities;

namespace Business.Interfaces;

public interface ITicketService
{
    Task<TicketEntity?> CreateTicketAsync(CreateTicketDto ticketDto, string invoiceId, string eventId, string bookingId);
    Task<IEnumerable<TicketEntity>> GetAllTicketsAsync();
    Task<TicketEntity?> GetTicketByIdAsync(int id);
}