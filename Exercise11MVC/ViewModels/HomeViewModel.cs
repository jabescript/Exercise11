namespace Exercise11MVC.ViewModels;

public class HomeViewModel
{
    public IEnumerable<PropertyViewModel> PropertiesOfTheWeek { get; }
    public HomeViewModel(IEnumerable<PropertyViewModel> propertiesOfTheWeek)
    {
        PropertiesOfTheWeek = propertiesOfTheWeek;
    }
}
