using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dulichvietlao.Models.Commands
{
    public class InsertTourCommand
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameTour { get; set; }
        public int? Day { get; set; }
        public int? Night { get; set; }
        public decimal? Cost { get; set; }
        public IFormFile Picture { get; set; }
        public bool? TopHot { get; set; }
        public bool? NewTour { get; set; }
        public decimal? Discount { get; set; }
        public bool CheckNational { get; set; }
        public int Check { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
