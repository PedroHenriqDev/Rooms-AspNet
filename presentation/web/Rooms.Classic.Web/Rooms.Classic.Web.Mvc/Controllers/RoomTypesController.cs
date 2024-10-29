using Rooms.Classic.Web.Mvc.Responses;
using Rooms.Classic.Web.App.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Rooms.Classic.Web.App.ViewModels;

namespace Rooms.Classic.Web.Mvc.Controllers
{
    public class RoomTypesController : Controller
    {
        private readonly IRoomTypeService _service;
        
        public RoomTypesController(IRoomTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> Edit(Guid id)
        {
            ApiResponse<RoomTypeViewModel> response = await _service.GetByIdAsync(id);

            if (response.HttpResponse.IsSuccessStatusCode && response.Value != null)
            {
                return View(response.Value);
            }

            return RedirectToNotFound();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            ApiResponse<RoomTypeViewModel> response = await _service.GetByIdAsync(id);

            if (response.HttpResponse.IsSuccessStatusCode && response.Value != null)
            {
                return View(response.Value);
            }

            return RedirectToNotFound();
        }

        [NonAction]
        public ActionResult RedirectToNotFound()
        {
            return RedirectToAction("NotFound", "Shared", new { model = "Room Type" });
        }
    }
}