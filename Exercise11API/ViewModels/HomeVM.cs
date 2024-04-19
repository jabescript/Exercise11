using Exercise11API.Models;

namespace Exercise11MVC.ViewModels;

public class HomeVM
{
    public IEnumerable<PropertyModel> PropertiesOfTheWeek { get; }
    public HomeVM(IEnumerable<PropertyModel> propertiesOfTheWeek)
    {
        PropertiesOfTheWeek = propertiesOfTheWeek;
    }
}
