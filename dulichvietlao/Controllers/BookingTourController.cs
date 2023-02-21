using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dulichvietlao.Models.Commands;
using Dulichvietlao.Models.Db;
using Dulichvietlao.Models.ViewModels;
using Dulichvietlao.Services;

namespace TourCore.Controllers
{
    public class BookingTourController : Controller
    {
        private readonly BookingService _bookingService;
        private readonly TourService _tourService;
       
        public BookingTourController(TourService tourService, BookingService bookingService)
        {
            this._bookingService = bookingService;
            this._tourService = tourService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BookingTour(BookingTourCommand command)
        {
            if(ModelState.IsValid)
            {
                this._bookingService.BookingTour(command);
                return RedirectToAction("Index","Home");
            }
            var model = _tourService.TourDetail(command.TourId);           
            return View("/Views/Tour/TourDetail.cshtml",model);
        }
        //public decimal TotalPeopleGo(BookingTourCommand command)
        //{
        //    decimal totalMoney = command.PeopleGo * 20000;
        //    return totalMoney;
        //}
        //public IActionResult a(BookingTourCommand command)
        //{
        //    return new PartialViewResult()
        //    {
        //        ViewData = TotalPeopleGo(command);
        //    };
        //}
    }
}