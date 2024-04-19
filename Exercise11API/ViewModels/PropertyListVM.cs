using Exercise11API.Models;

namespace Exercise11MVC.ViewModels;

public class PropertyListVM
{
    public IEnumerable<PropertyModel> Properties { get; set; }

    public PropertyListVM(IEnumerable<PropertyModel> properties)
    {
        Properties = properties;
    }
}
