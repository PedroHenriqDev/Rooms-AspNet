﻿using Rooms.Classic.Web.Mvc.Services.Interfaces;
using Rooms.Classic.Web.Mvc.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

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
    }
}