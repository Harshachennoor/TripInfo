using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TripInfo.Models;

namespace TripInfo.Controllers;

public class HomeController : Controller
{
    private TripContext _context;

    public HomeController(TripContext ctx)
    {
        _context = ctx;
    }

    public IActionResult Index()
    {
        //Passing the data by checking the cookie by deserializing
        var tripDetails = new TripViewModel();
        if(Request.Cookies["tripDetails"]!=null){
            
            tripDetails = JsonConvert.DeserializeObject<TripViewModel>(Request.Cookies["tripDetails"]);
        }
        return View(tripDetails);
    }

}
