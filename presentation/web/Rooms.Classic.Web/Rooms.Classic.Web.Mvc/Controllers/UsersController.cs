using Rooms.Classic.Web.App.Dtos.Responses.Abstractions;
using Rooms.Classic.Web.App.Services.Interfaces;
using Rooms.Classic.Web.App.ViewModels;
using Rooms.Classic.Web.App.ViewModels.Users;
using Rooms.Classic.Web.Mvc.Responses;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Rooms.Classic.Web.Mvc.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Register(RegisterUserViewModel viewModel)
        {
            ApiResponse apiResponse = await _userService.RegisterAsync(viewModel);
            Response.StatusCode = (int)apiResponse.HttpResponse.StatusCode;
            return Json(apiResponse);
        }
    }
}