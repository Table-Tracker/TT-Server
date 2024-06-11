using System;

namespace TT.Restaurant.Domain.Models;
public class MenuItem : Model
{
    public string? Name { get; set; }
    public string? Ingredients { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }

    public Guid MenuSectionId { get; set; }
    public MenuSection? MenuSection { get; set; }
}
