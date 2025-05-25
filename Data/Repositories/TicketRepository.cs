using Data.Contexts;
using Data.Entities;
using Data.Interfaces;


namespace Data.Repositories;

public class TicketRepository : BaseRepository<TicketEntity>, ITicketRepository
{
    public TicketRepository(DataContext context) : base(context)
    {
    }

}
