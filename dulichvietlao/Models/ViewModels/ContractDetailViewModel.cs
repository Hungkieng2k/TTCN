using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Dulichvietlao.Models.ViewModels
{
    public class ContractDetailViewModel
    {
        public int Id { get; set; }
        public int PeopleGo { get; set; }
        [DisplayName("Giá tiền")]
        public decimal? Cost { get; set; }
        [DisplayName("Tên tour")]
        public string NameTour { get; set; }
        public int ContractId { get; set; }
        [DisplayName("Mã tour")]
        public string Code { get; set; }
        [DisplayName("Tên khách hàng")]
        public string NameCustomer { get; set; }
        [DisplayName("Ngày đặt tour")]
        public DateTime BeginDate { get; set; }
        [DisplayName("Tình trạng thanh toán")]
        public bool Paid { get; set; }
        public int TourId { get; set; }
        public int StaffId { get; set; }
        public string Picture { get; set; }
        public string Email { get; set; }

    }
}
