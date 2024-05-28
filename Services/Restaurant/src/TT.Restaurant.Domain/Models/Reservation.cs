using System;

namespace TT.Restaurant.Domain.Models;
public class Reservation : Model
{
    public DateTime ReservationDate { get; set; }
    public Guid VisitorId { get; set; }

    public Guid TableId { get; set; }
    public Table? Table { get; set; }
}
