using Business.Dtos;
using Data.Contexts;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTicket(int id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
            return NotFound();


        var eventDetails = new
        {
            EventName = "Rhythm & Beats Music Festival",
            Location = "Sunset Park, Los Angeles, CA",
            Date = "2029-04-20T12:00:00"
        };

        return Ok(new
        {
            ticket.Id,
            ticket.InvoiceId,
            ticket.SeatNumber,
            ticket.Gate,
            ticket.Category,
            ticket.EventId,
            eventDetails.EventName,
            eventDetails.Location,
            eventDetails.Date
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTickets()
    {
        var tickets = await _context.Tickets.ToListAsync();
        return Ok(tickets); 
    }


    [HttpPost]
    public async Task<IActionResult> CreateTickets([FromBody] CreateTicketsRequest request)
    {
        var tickets = request.Tickets.Select(t => new TicketEntity
        {
            InvoiceId = request.InvoiceId,
            SeatNumber = t.SeatNumber,
            Gate = t.Gate,
            Category = t.Category,
            EventId = request.EventId.ToString(),
            BookingId = request.BookingId.ToString()
        }).ToList();

        _context.Tickets.AddRange(tickets);
        await _context.SaveChangesAsync();

        return Ok(tickets);
    }
}
