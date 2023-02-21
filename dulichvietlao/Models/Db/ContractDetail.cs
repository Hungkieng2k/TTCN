using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Dulichvietlao.Models.ViewModels;

namespace Dulichvietlao.Models.Db
{
    [Table("ContractDetail")]
    public class ContractDetail
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int PeopleGo { get; set; }
        public decimal? Cost { get; set; }
        public string NameTour { get; set; }
        public int TourId { get; set; }
        public int? StaffId { get; set; }

        public ContractDetail(ContractDetailViewModel contractDetail)
        {
            this.Id = contractDetail.Id;
            this.ContractId = contractDetail.Id;
            this.PeopleGo = contractDetail.PeopleGo;
            this.Cost = contractDetail.Cost;
            this.NameTour = contractDetail.NameTour;
            this.TourId = contractDetail.TourId;
            this.StaffId = contractDetail.StaffId;
        }
        public ContractDetail()
        {

        }
    }
}
