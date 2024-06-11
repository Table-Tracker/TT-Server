using System;
using System.Collections.Generic;

namespace TT.Restaurant.Domain.Models;
public class MenuSection : Model
{
    public Guid RestaurantId { get; set; }
    public Restaurant? Restaurant { get; set; }

    public required ICollection<MenuItem> MenuItems { get; set; }
}
