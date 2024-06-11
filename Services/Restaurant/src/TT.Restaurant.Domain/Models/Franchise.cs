using System.Collections.Generic;

namespace TT.Restaurant.Domain.Models;
public class Franchise : Model
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    
    public required ICollection<Restaurant> Restaurants { get; set; }
}
