using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Dulichvietlao.Models.Commands;
using Dulichvietlao.Models.ViewModels;

namespace Dulichvietlao.Models.Db
{
    [Table("Tour")]
    public class Tour
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameTour { get; set; }
        public int? Day { get; set; }
        public int? Night { get; set; }
        public decimal? Cost { get; set; }
        public string Picture { get; set; }
        public bool? TopHot { get; set; }
        public bool? NewTour { get; set; }
        public decimal? Discount { get; set; }
        public bool? Domestic { get; set; }
        public bool? National { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }



        public Tour(TourViewModel tourViewModel)
        {
            this.Id = tourViewModel.Id;
            this.Cost = tourViewModel.Cost;
            this.Code = tourViewModel.Code;
            this.NameTour = tourViewModel.NameTour;
            this.Day = tourViewModel.Day;
            this.Night = tourViewModel.Night;
            this.Picture = tourViewModel.Picture;
            this.TopHot = tourViewModel.TopHot;
            this.NewTour = tourViewModel.NewTour;
            this.Discount = tourViewModel.Discount;
            this.Description = tourViewModel.Description;
            this.Title = tourViewModel.Title;
        }
        public Tour()
        {

        }
    }
}
