using Rooms.Classic.Web.Mvc.Responses;
using Rooms.Classic.Web.App.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Rooms.Classic.Web.App.ViewModels;
using Rooms.Classic.Web.App.Dtos.Responses.Abstractions;

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

        [HttpPost]
        public async Task<JsonResult> Create(RoomTypeViewModel viewModel)
        {
            ApiResponse apiResponse = await _service.CreateAsync(viewModel);
            Response.StatusCode = (int)apiResponse.HttpResponse.StatusCode;
            return Json(apiResponse);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> Edit(Guid id)
        {
            ApiResponse response = await _service.GetByIdAsync(id);

            if (response.HttpResponse.IsSuccessStatusCode)
                return View(((ApiSuccessResponse<RoomTypeViewModel>)response).Value);

            return RedirectToNotFound();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            ApiResponse response = await _service.GetByIdAsync(id);

            if (response.HttpResponse.IsSuccessStatusCode)
            {
                return View(((ApiSuccessResponse<RoomTypeViewModel>)response).Value);
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