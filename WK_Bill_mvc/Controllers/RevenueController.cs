using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.WK_Servcie.IService;
using Domain.WK_Dto.RevenueDto;
using Microsoft.AspNetCore.Mvc;

namespace WK_Bill_mvc.Controllers
{
    [Route("Revenue/[Action]")]
    public class RevenueController : Controller
    {
        private readonly IAddRevenueService _addRevenueService;

        public RevenueController(IAddRevenueService addRevenueService)
        {
            _addRevenueService = addRevenueService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _addRevenueService.QueryAsync();
            return View(list);
        }

        public async Task<IActionResult> DeleteRevenue(Guid id)
        {
            var dto = await _addRevenueService.GetHasEntity(id);
            if (dto)
            {
                var addDto = _addRevenueService.GetEntityByKey(id);
                _addRevenueService.Delete(addDto);
                var num = await _addRevenueService.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public IActionResult AddRevenue()
        {
            return View();
        }
    }
}
