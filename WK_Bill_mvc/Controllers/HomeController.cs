using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.EntityFrameWorkCore.SQLServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WK_Bill_mvc.Models;

namespace WK_Bill_mvc.Controllers
{
    [Route("Home/[Action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WkBillContext _wkBillContext;
        public HomeController(ILogger<HomeController> logger,WkBillContext wkBillContext)
        {
            _logger = logger;
            _wkBillContext = wkBillContext;
        }

        public async Task<IActionResult> Index()
        {
            var billTypeList = await _wkBillContext.BillTypes.ToListAsync();
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
    }
}
