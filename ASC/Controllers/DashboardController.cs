﻿using ASC.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace ASC.Controllers
{
    public class DashboardController : BaseController
    {
        private IOptions<ApplicationSettings> _settings;
        public DashboardController(IOptions<ApplicationSettings> settings)
        {
            _settings = settings;
        }
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
