using Exercise11API.Data;
using Exercise11API.Repository;
using Microsoft.EntityFrameworkCore;

namespace Exercise11API.Models;

public class PropertyRepository : IPropertyRepository
{
    private readonly PropertyDbContext _propertyDbContext;

    public PropertyRepository(PropertyDbContext propertyDbContext)
    {
        _propertyDbContext = propertyDbContext;
    }

    public IEnumerable<PropertyModel> AllProperties
    {
        get
        {
            return _propertyDbContext.Properties.Select(p => p);
        }
    }

    public IEnumerable<PropertyModel> PropertiesOfTheWeek
    {
        get
        {
            return _propertyDbContext.Properties.Include(p => p.IsPropertyOfTheWeek);
        }
    }

    public PropertyModel? GetPropertyById(int id)
    {
        return _propertyDbContext.Properties.FirstOrDefault(p => p.PropertyId == id);
    }

    public IEnumerable<PropertyModel> SearchProperties(string searchQuery)
    {
        throw new NotImplementedException();
    }
}
