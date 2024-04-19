namespace Exercise11MVC.ViewModels;

public class PropertyListViewModel
{
    public IEnumerable<PropertyViewModel> Properties { get; set; }

    public PropertyListViewModel(IEnumerable<PropertyViewModel> properties)
    {
        Properties = properties;
    }
}
