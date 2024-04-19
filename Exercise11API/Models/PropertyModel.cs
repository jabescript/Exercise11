using System.ComponentModel.DataAnnotations;

namespace Exercise11API.Models;

public class PropertyModel
{
    [Key]
    public int PropertyId { get; set; }
    public string? Title { get; set; }
    public decimal Price { get; set; }
    public string? SummaryDescription { get; set; }
    public string? DetailDescription { get; set; }
    public int CarSpace { get; set; }
    public int NumberOfBedroom { get; set; }
    public int NumberOfBathroom { get; set; }
    public int FloorArea { get; set; }
    public int LandSize { get; set; }
    public string? Location { get; set; }
    public string? ImageUrl { get; set; }
    //public IFormFile? Image { get; set; }
    public string? BrokerName { get; set; }
    public string? BrokerEmail { get; set; }
    public string? BrokerPhone { get; set; }
    public bool IsPropertyOfTheWeek { get; set; }
    public string PropertyCategory { get; set; } = string.Empty;
}
