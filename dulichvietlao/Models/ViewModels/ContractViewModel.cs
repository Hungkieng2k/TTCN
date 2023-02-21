using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dulichvietlao.Models.ViewModels
{
    public class ContractViewModel
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public bool Paid { get; set; }
        public string Content { get; set; }
        public int TourId { get; set; }

        public int? MembershipId { get; set; }

        public int CustomerId { get; set; }

        public int? GroupId { get; set; }
    }
}
