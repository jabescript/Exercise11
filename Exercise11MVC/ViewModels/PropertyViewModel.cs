using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise11MVC.ViewModels;

public partial class PropertyViewModel
{
    [Key]
    [Required(ErrorMessage = "Please enter the property ID")]
    [Range(1000,100000000)]
    [Display(Name = "Property ID")]
    public int PropertyId { get; set; }

    [Required(ErrorMessage = "Please enter the title")]
    [Display(Name = "Title")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Please enter the price")]
    [Display(Name = "Price")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Please enter the summary description")]
    [Display(Name = "Summary Description")]
    public string SummaryDescription { get; set; }

    [Required(ErrorMessage = "Please enter the detail description")]
    [Display(Name = "Detail Description")]
    public string DetailDescription { get; set; }

    [Required(ErrorMessage = "Please enter the car space")]
    [Display(Name = "Car Space")]
    public int CarSpace { get; set; }

    [Required(ErrorMessage = "Please enter the number of bedroom")]
    [Display(Name = "Number Of Bedroom")]
    public int NumberOfBedroom { get; set; }

    [Required(ErrorMessage = "Please enter the number of bathroom")]
    [Display(Name = "Number Of Bathroom")]
    public int NumberOfBathroom { get; set; }

    [Required(ErrorMessage = "Please enter the floor area")]
    [Display(Name = "Floor Area")]
    public int FloorArea { get; set; }

    [Required(ErrorMessage = "Please enter the land size")]
    [Display(Name = "Land Size")]
    public int LandSize { get; set; }

    [Required(ErrorMessage = "Please enter the location")]
    [Display(Name = "Location")]
    public string Location { get; set; }

    [Required(ErrorMessage = "Please enter the image URL")]
    [Display(Name = "Image URL")]
    public string ImageUrl { get; set; }

    [Required(ErrorMessage = "Please enter the broker name")]
    [Display(Name = "Broker Name")]
    public string BrokerName { get; set; }

    [Required(ErrorMessage = "Please enter the broker email")]
    [Display(Name = "Broker Email")]
    public string BrokerEmail { get; set; }

    [Required(ErrorMessage = "Please enter the broker phone")]
    [Display(Name = "Broker Phone")]
    public string BrokerPhone { get; set; }

    public bool IsPropertyOfTheWeek { get; set; }
    [Required(ErrorMessage = "Please enter the property category")]
    public string PropertyCategory { get; set; } = string.Empty;

}
