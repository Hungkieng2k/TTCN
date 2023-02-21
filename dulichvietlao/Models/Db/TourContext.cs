using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dulichvietlao.Models.ViewModels;

namespace Dulichvietlao.Models.Db
{
    public class DulichvietlaoContext : DbContext
    {
        public DulichvietlaoContext(DbContextOptions options):base(options)
        { }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractDetail> ContractDetails { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Manage> Manages { get; set; }



    }
}
