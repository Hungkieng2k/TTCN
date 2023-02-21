using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dulichvietlao.Services;

namespace Dulichvietlao.Components
{
    public class CountViewComponent : ViewComponent
    {
        private readonly QuantitySevice _quantitySevice;
        public CountViewComponent(QuantitySevice quantitySevice)
        {
            this._quantitySevice = quantitySevice;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.Number = NumberMember();
            ViewBag.Booking = NumberBooking();
            return View();
        }
        public int NumberMember()
        {
            int number = this._quantitySevice.NumberMember();
            return number;
        }
        public int NumberBooking()
        {
            int number = this._quantitySevice.NumberBooking();
            return number;
        }
    }
}
