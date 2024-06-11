using System;
using System.Collections.Generic;

namespace TT.Restaurant.Domain.Models;
public class Restaurant : Model
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }

    public Guid FranchiseId { get; set; }
    public Franchise? Franchise { get; set; }

    public ICollection<Table>? Tables { get; set; }
    public required ICollection<MenuSection> MenuSections { get; set; }
}
