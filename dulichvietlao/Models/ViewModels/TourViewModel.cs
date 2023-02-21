using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Dulichvietlao.Models.Db;

namespace Dulichvietlao.Models.ViewModels
{
    public class TourViewModel
    {
        public int Id { get; set; }
        [DisplayName("Mã Tour")]
        public string Code { get; set; }
        [DisplayName("Tên Tour")]
        public string NameTour { get; set; }
        [DisplayName("Ngày")]
        public int? Day { get; set; }
        [DisplayName("Đêm")]
        public int? Night { get; set; }
        [DisplayName("Giá Tiền")]
        public decimal? Cost { get; set; }
        [DisplayName("Hình ảnh")]
        public string Picture { get; set; }
        public bool TopHot { get; set; }
        public bool NewTour { get; set; }
        public decimal? Discount { get; set; }
        public int NumberBooking { get; set; }
        public string Description { get; set; }
        public bool Domestic { get; set; }
        public bool National { get; set; }
        [DisplayName("Số lượng")]
        public int? Quantity { get; set; }
        public string Title { get; set; }
    }
}
