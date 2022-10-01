﻿using Calculator.AspNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace Calculator.AspNetCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataTable _dataTable = new DataTable();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult Result(string inputVal)
        {
            try
            {
                var result = Math.Round(Convert.ToDouble(_dataTable.Compute(inputVal.Replace(",", "."), "")), 2).ToString();
                return Json(new { success = true, result });
            }
            catch (Exception exception)
            {
                return Json(new { success = false, message = exception.Message });
                throw;
            }
        }
    }
}