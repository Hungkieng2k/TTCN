using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dulichvietlao.Models.ViewModels
{
    public class StaffViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public bool Gender { get; set; }
    }
}
