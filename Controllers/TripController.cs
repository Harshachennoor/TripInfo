using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TripInfo.Models;

namespace TripInfo.Controllers
{
    public class TripController : Controller
    {
        private TripContext _context;

        public TripController(TripContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        public IActionResult Add(string id = "")
        {
            if (id.ToLower() == "page2")
            {
                //Passing the Accommodation value entered by the user to Add2 to display in SubHeader by deserializing 
                ViewBag.accName = JsonConvert.DeserializeObject<Trip>(HttpContext.Session.GetString("Trip")).Accommodation.ToString();
                return View("Add2", new Accommodation());
            }
            else if (id.ToLower() == "page3")
            {
                //Passing the Destination value entered by the user to Add3 to display in SubHeader by deserializing
                ViewBag.desName = JsonConvert.DeserializeObject<Trip>(HttpContext.Session.GetString("Trip")).Destination.ToString();
                return View("Add3", new ThingsToDo());
            }
            else
            {
                return View("Add1", new Trip());
            }


        }

        [HttpPost]
        public IActionResult Add1(Trip trip)
        {
            if (ModelState.IsValid)
            {
                //Serializing the object with reference name Trip
                HttpContext.Session.SetString("Trip", JsonConvert.SerializeObject(trip));

                return RedirectToAction("Add", new { id = "Page2" });
            }
            else
            {
                return View("Add1", trip);
            }
        }

        [HttpPost]
        public dynamic Add2(Accommodation acc)
        {
            //Retrieving the distinct existing records of Emails and PhoneNumbers from the database
            var uniqueEmails = _context.ExistingDatas.Select(e => e.Email).Distinct().ToList();
            var uniquePhoneNumber = _context.ExistingDatas.Select(p => p.PhoneNumber).Distinct().ToList();
            var phoneNumber = acc.PhoneNumber;
            var email = acc.Email;

            //Server-side Validation 
            if(uniquePhoneNumber.Contains(phoneNumber)){
                ModelState.AddModelError(nameof(acc.PhoneNumber), "Phone number already exists, try with other phone number");
            }
            if(uniqueEmails.Contains(email)){
                ModelState.AddModelError(nameof(acc.Email),"Email already exists, try with other email");
            }

            if (ModelState.IsValid)
            {

                String str = JsonConvert.DeserializeObject<Trip>(HttpContext.Session.GetString("Trip")).Accommodation.ToString();
                acc.Name = str;

                /* Lines can be uncommented if you want to add the current Email and PhoneNumber to the database */
                // var accomdation = new ExistingData{PhoneNumber=acc.PhoneNumber,Email=acc.Email};
                // _context.ExistingDatas.Add(accomdation);
                // _context.SaveChanges();

                HttpContext.Session.SetString("AccomodationDetails", JsonConvert.SerializeObject(acc));

                return RedirectToAction("Add", new { id = "Page3" });
            }
            else
            {
                
                return View("Add2", acc);
            }
        }
        [HttpPost]
        public IActionResult Add3(ThingsToDo t)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("ThingsToDoDetails", JsonConvert.SerializeObject(t));

                TripViewModel vm = JsonConvert.DeserializeObject<TripViewModel>(HttpContext.Session.GetString("Trip"));
                vm.AccommodationDetails = JsonConvert.DeserializeObject<Accommodation>(HttpContext.Session.GetString("AccomodationDetails"));
                vm.ThingsToDoDetails = JsonConvert.DeserializeObject<ThingsToDo>(HttpContext.Session.GetString("ThingsToDoDetails"));

                //Creating a cookie and adding the Serialized object with expiration time
                CookieOptions op = new CookieOptions();
                op.Expires = DateTime.Now.AddDays(3);

                Response.Cookies.Append("tripDetails", JsonConvert.SerializeObject(vm), op);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Add3", t);
            }
        }

        //Cancel to Redirect to Home page
        public RedirectToActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}