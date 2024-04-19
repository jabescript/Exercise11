using Exercise11MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Exercise11MVC.Controllers;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly string _baseURL;

    public HomeController(IConfiguration configuration)
    {
        _configuration = configuration;
        _baseURL = _configuration["WebApiUrl"];
    }

    public ActionResult Index()
    {
        IEnumerable<PropertyViewModel> propertiesOfTheWeek = null;

        using(var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_baseURL);
            var responseTask = client.GetAsync("api/propertiesoftheweek");
            responseTask.Wait();

            var result = responseTask.Result;
            if(result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<PropertyViewModel>>();
                readTask.Wait();

                propertiesOfTheWeek = readTask.Result;
            }
            else
            {
                propertiesOfTheWeek = Enumerable.Empty<PropertyViewModel>();
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
        }

        var homeViewModel = new HomeViewModel(propertiesOfTheWeek);

        return View(homeViewModel);
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult FAQs()
    {
        return View();
    }

    //public IActionResult Privacy()
    //{
    //    return View();
    //}

    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //public IActionResult Error()
    //{
    //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //}
}
