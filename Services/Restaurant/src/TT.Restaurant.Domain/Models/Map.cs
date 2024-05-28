using System;

namespace TT.Restaurant.Domain.Models;
public class Map : Model
{
    public string? Base64MapData { get; set; }
    
    public Guid RestaurantId { get; set; }
    public Restaurant? Restaurant { get; set; }
}
