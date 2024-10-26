using System.Web.Mvc;

namespace Rooms.Classic.Web.Mvc.Controllers
{
    public class SharedController : Controller
    {
        [HttpGet]
        [Route("model:alpha")]
        public ActionResult NotFound(string model)
        {
            if(string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
            {
                return RedirectToAction("Index", "RoomTypes");
            }

            ViewBag.Model = model;

            return View();
        }
    }
}