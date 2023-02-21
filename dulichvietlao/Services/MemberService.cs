using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dulichvietlao.Models.Db;
using Dulichvietlao.Models.ViewModels;


namespace Dulichvietlao.Services
{
    public class MemberService
    {
        private readonly DulichvietlaoContext _db;
        public MemberService(DulichvietlaoContext tourContext)
        {
            this._db = tourContext;
        }
        public void SaveInfoMember(MemberViewModel viewModel)
        {
            var saveInfoMember = new Member();
            {
                saveInfoMember.Username = viewModel.Username;
                saveInfoMember.Password = viewModel.Password;
                saveInfoMember.Email = viewModel.Email;
            }
            this._db.Members.Add(saveInfoMember);
            this._db.SaveChanges();
        }
        public bool LoginMember(string Username,string Password)
        {
            var check = _db.Members.ToList();
            var result = check.Count(n => n.Username == Username && n.Password == Password);
            if (result >0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
