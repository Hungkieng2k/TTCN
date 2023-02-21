using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Dulichvietlao.Models.ViewModels;

namespace Dulichvietlao.Models.Db
{
    [Table("Contract")]
    public class Contract
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public bool Paid { get; set; }
        public string Content { get; set; }
        public int TourId { get; set; }
        public int? MembershipId { get; set; }

        public int CustomerId { get; set; }

        public int? GroupId { get; set; }

        //public Group Group { get; set; }
        //public void Test()
        //{

        //    // EF read group id = 1
        //    // => table group => select * from Group where GroupId = 1
        //    // => map data to this.Group
        //    // 
            
        //    this.Group.GroupName = "Test";
        //    // EF track changes: GroupName = "Test"
        //    // db.SaveChanges() => update Group set GroupName ="test" where GroupId = 1

        //}
        public Contract(ContractViewModel contract)
        {
            this.Id = contract.Id;
            this.BeginDate = contract.BeginDate;
            this.Paid = contract.Paid;
            this.Content = contract.Content;
            this.CustomerId = contract.CustomerId;
            this.TourId = contract.TourId;
        }
        public Contract()
        {

        }
    }
}
