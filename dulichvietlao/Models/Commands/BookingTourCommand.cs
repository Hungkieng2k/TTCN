    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dulichvietlao.Models.Commands
{
    public class BookingTourCommand
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Tên khách hàng không được để trống !!!")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Địa chỉ không được để trống!!!")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Điện thoại không được để trống!!!")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage ="Số điện thoại không hợp lệ !!!")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Email không được để trống!!!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail không hợp lệ!!!")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Số người đi không được để trống!!!")]
        [Range(0,50, ErrorMessage = "Số người đi không hợp lệ")]
        public string PeopleGo { get; set; }
        public DateTime BeginDate { get; set; }
        public int TourId { get; set; }
        public string Content { get; set; }

    }
}
