using System;
using System.Collections.Generic;

namespace TT.Restaurant.Domain.Models;
public class Table : Model
{
    public int InsideNumber { get; set; }
    public int TableSize { get; set; }
    public int GuestNumber { get; set; }

    public Guid RestaurantId { get; set; }
    public Restaurant? Restaurant { get; set; }

    public ICollection<Reservation>? Reservations { get; set; }
}
