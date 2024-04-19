using Exercise11API.Data;
using Exercise11API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exercise11API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropertiesOfTheWeekController : ControllerBase
{
    private readonly PropertyDbContext _context;
    public PropertiesOfTheWeekController(PropertyDbContext context)
    {
        _context = context;
    }

    // GET: api/PropertiesOfTheWeek
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PropertyModel>>> GetPropertiesOfTheWeek()
    {
        return await _context.Properties.Where(p => p.IsPropertyOfTheWeek).ToListAsync();
    }

    // Post: api/PropertiesOfTheWeek

}
