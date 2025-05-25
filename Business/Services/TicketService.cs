using Business.Dtos;
using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;

namespace Business.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<TicketEntity?> CreateTicketAsync(CreateTicketDto ticketDto, string invoiceId, string eventId, string bookingId)
    {
        var ticket = new TicketEntity
        {
            InvoiceId = invoiceId,
            SeatNumber = ticketDto.SeatNumber,
            Gate = ticketDto.Gate,
            Category = ticketDto.Category,
            EventId = eventId,
            BookingId = bookingId
        };

        return await _ticketRepository.AddAsync(ticket);
    }

    public async Task<TicketEntity?> GetTicketByIdAsync(int id)
    {
        return await _ticketRepository.GetAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<TicketEntity>> GetAllTicketsAsync()
    {
        return await _ticketRepository.GetAllAsync();
    }
}
