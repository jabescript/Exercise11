using Exercise11API.Data;
using Exercise11API.Models;
using Exercise11API.Repository;
using Exercise11API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exercise11API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropertiesController : ControllerBase
{
    private readonly PropertyDbContext _context;
    private readonly IStorageService _blobStorageService;

    public PropertiesController(PropertyDbContext context, IStorageService blobStorageService)
    {
        _context = context;
        _blobStorageService = blobStorageService;
    }

    // GET: api/Properties
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PropertyModel>>> GetProperties()
    {
        return await _context.Properties.ToListAsync();
        //return await _propertyRepository.AllProperties;
    }

    // GET: api/Properties/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PropertyModel>> GetPropertyModel(int id)
    {
        var propertyModel = await _context.Properties.FindAsync(id);

        if (propertyModel == null)
        {
            return NotFound();
        }

        return propertyModel;
    }

    // PUT: api/Properties/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPropertyModel(int id, PropertyModel propertyModel)
    {
        if (id != propertyModel.PropertyId)
        {
            return BadRequest();
        }

        _context.Entry(propertyModel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PropertyModelExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Properties
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    //public async Task<ActionResult<PropertyModel>> PostPropertyModel(PropertyModel propertyModel, IFormFile file)
    public async Task<IActionResult> PostPropertyModel(PropertyModel propertyModel)
    {
        _context.Properties.Add(propertyModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPropertyModel", new { id = propertyModel.PropertyId }, propertyModel);
    }

    // DELETE: api/Properties/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePropertyModel(int id)
    {
        var propertyModel = await _context.Properties.FindAsync(id);
        if (propertyModel == null)
        {
            return NotFound();
        }

        _context.Properties.Remove(propertyModel);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PropertyModelExists(int id)
    {
        return _context.Properties.Any(e => e.PropertyId == id);
    }
}
