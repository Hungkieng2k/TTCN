using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dulichvietlao.Models.Db;
using Dulichvietlao.Models.ViewModels;
using Dulichvietlao.Services;

namespace Dulichvietlao.Controllers
{
    public class TourController : Controller
    {
        private readonly TourService _tourService;
        private readonly DulichvietlaoContext _db;
        public TourController(TourService tourService, DulichvietlaoContext db)
        {
            this._db = db;
            this._tourService = tourService;
        }
        public IActionResult Domestic()
        {
            var model = this._tourService.Domestic();
            return View(model);
        }
        public IActionResult National()
        {
            var model = this._tourService.National();
            return View(model);
        }
        public IActionResult TourDetail(int? id)
        {
            if(id==null)
            {
                return View("/Views/Shared/Error.cshtml");
            }
            var model = _tourService.TourDetail(id);
            if(model==null)
            {
                return null;
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult FindTour(string nameTour/*,DateTime beginDate*/)
        {
            if(nameTour==null)
            {
                return RedirectToAction("Domestic","Tour");
            }
            var model= this._tourService.FindTour(nameTour);
            return View(model);
        }
    }
}