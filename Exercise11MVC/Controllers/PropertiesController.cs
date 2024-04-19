using Exercise11MVC.Services;
using Exercise11MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Exercise11MVC.Controllers;
public class PropertiesController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly string _baseURL;
    private readonly IStorageService _storageService;

    public PropertiesController(IConfiguration configuration, IStorageService storageService)
    {
        _configuration = configuration;
        _baseURL = _configuration["WebApiURL"];
        _storageService = storageService;
    }

    // GET: PropertiesController
    public ActionResult AllProperties()
    {
        IEnumerable<PropertyViewModel> properties = null;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_baseURL);

            var response = client.GetAsync("api/properties");
            response.Wait();

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsAsync<IList<PropertyViewModel>>();
                read.Wait();

                properties = read.Result;
            }
            else
            {
                properties = Enumerable.Empty<PropertyViewModel>();
                ModelState.AddModelError(string.Empty, "Server error. Please contact your administrator.");
            }
        }

        var propertyListViewModel = new PropertyListViewModel(properties);

        return View(propertyListViewModel);
    }

    // GET: PropertiesController/Details/5
    public ActionResult Details(int id)
    {
        if (id == null)
        {
            return BadRequest();
        }

        PropertyViewModel properties = null;

        using (var client = new HttpClient())
        {

            client.BaseAddress = new Uri(_baseURL);

            var response = client.GetAsync("api/properties/" + id.ToString());
            response.Wait();

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsAsync<PropertyViewModel>();
                read.Wait();

                properties = read.Result;
            }
        }

        if (properties == null)
        {
            return NotFound();
        }

        return View(properties);
    }

    // GET: PropertiesController/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PropertiesController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(PropertyViewModel property, IFormFile file)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_baseURL);

            if (file != null)
            {
                string url = _storageService.UploadFileToAzureStorage(file);

                property.ImageUrl = url;
            }

            var post = client.PostAsJsonAsync("api/properties", property);
            post.Wait();

            var result = post.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("AllProperties");
            }
        }

        ModelState.AddModelError(string.Empty, "Server error. Please contact your administrator.");

        return View(property);
    }

    // GET: PropertiesController/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return BadRequest();
        }

        PropertyViewModel? properties = null;

        using (var client = new HttpClient())
        {

            client.BaseAddress = new Uri(_baseURL);

            var response = client.GetAsync("api/properties/" + id.ToString());
            response.Wait();

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsAsync<PropertyViewModel>();
                read.Wait();

                properties = read.Result;
            }
        }

        if (properties == null)
        {
            return NotFound();
        }

        return View(properties);
    }

    // POST: PropertiesController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, PropertyViewModel property)
    {
        using (var client = new HttpClient())
        {

            client.BaseAddress = new Uri(_baseURL);

            var put = client.PutAsJsonAsync<PropertyViewModel>("api/properties/" + id.ToString(), property);
            put.Wait();

            var result = put.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("AllProperties");
            }
        }

        return View(property);
    }

    // GET: PropertiesController/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return BadRequest();
        }

        PropertyViewModel properties = null;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_baseURL);

            var response = client.GetAsync("api/properties/" + id.ToString());

            response.Wait();

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsAsync<PropertyViewModel>();
                read.Wait();

                properties = read.Result;
            }
        }

        if (properties == null)
        {
            return NotFound();
        }

        return View(properties);
    }

    // POST: PropertiesController/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_baseURL);

            var delete = await client.DeleteAsync("api/properties/" + id.ToString());

            if (delete.IsSuccessStatusCode)
            {
                return RedirectToAction("AllProperties");
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
