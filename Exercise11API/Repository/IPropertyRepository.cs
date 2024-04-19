using Exercise11API.Models;

namespace Exercise11API.Repository;

public interface IPropertyRepository
{
    IEnumerable<PropertyModel> AllProperties { get; }
    IEnumerable<PropertyModel> PropertiesOfTheWeek { get; }
    PropertyModel? GetPropertyById(int id);
    IEnumerable<PropertyModel> SearchProperties(string searchQuery);
}
