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
    [Table("Customer")]
    public class Customer
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
        public int? MembershipId { get; set; }

        public Customer(BookingTourCommand command)
        {
            this.Name = command.Name;
            this.Address = command.Address;
            this.Phone = command.Phone;
            this.Email = command.Email;
        }
        public Customer(CustomerViewModel customer)
        {
            this.Id = customer.Id;
            this.Name = customer.Name;
            this.Address = customer.Address;
            this.Email = customer.Email;
            this.Phone = customer.Phone;
        }
        public Customer()
        { }

    }
}
