﻿using Microsoft.AspNetCore.Mvc;

namespace Medical_Information_System_API.Controllers
{
    [ApiController]
    [Route("api/inspection")]
    public class InspectionController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
