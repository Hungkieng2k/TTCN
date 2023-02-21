using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dulichvietlao.Models.ViewModels
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Tài khoản không được để trống")]
        [StringLength(20,ErrorMessage ="Không viết trên 20 kí tự!!!")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Mật khẩu không được để trống!!!")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Email không được để trống !!!")]
        public string Email { get; set; }
        public int? MembershipId { get; set; }

    }
}
