using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dulichvietlao.Models.Commands;
using Dulichvietlao.Models.Db;
using Dulichvietlao.Models.ViewModels;

namespace DulichvietlaoCore.Services
{
    public class StaffService
    {
        private readonly DulichvietlaoContext _db;
        public StaffService(DulichvietlaoContext db)
        {
            this._db = db;
        }
        public void AddStaff(StaffCommand staffCommand)
        {
            var newStaff = new Staff();
            {
                newStaff.Name = staffCommand.Name;
                newStaff.Phone = staffCommand.Phone;
                newStaff.DOB = staffCommand.DOB;
                newStaff.Address = staffCommand.Address;
                newStaff.Gender = staffCommand.Gender;
            }
            _db.Staffs.Add(newStaff);
            _db.SaveChanges();
        }
        public List<StaffViewModel> AllStaff()
        {
            var listStaff = new List<StaffViewModel>();
            using (var connection = new SqlConnection(this._db.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                listStaff = connection.Query<StaffViewModel>(@"Select * From Staff").ToList();
                connection.Close();
            }
            return listStaff;
        }
    }
}
