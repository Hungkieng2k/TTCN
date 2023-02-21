using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dulichvietlao.Models.Db;
using Dulichvietlao.Models.ViewModels;

namespace Dulichvietlao.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DulichvietlaoContext _db;
        public CustomerController(DulichvietlaoContext db)
        {
            this._db = db;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Username,string Password)
        {
            //string Username = f["Username"].ToString();
            //string Password = f["Password"].ToString();
            Account ac = _db.Accounts.SingleOrDefault(n => n.Username == Username && n.Password == Password);
          
            if (ac != null)
            {
                var session = HttpContext.Session;
                var sessionValue= JsonSerializer.Serialize(ac); // convert object to string
                session.SetString("Account", sessionValue); // Session["Account"] = sessionValue;


                var data = session.GetString("Account"); // "1"  data = Session["Account"];
                var acData = JsonSerializer.Deserialize<Account>(data);

                return RedirectToAction("Index","Home");
            }
            string content = "Login failed";
            ViewBag.content = content;
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Account account)
        {
            _db.Accounts.Add(account);
            _db.SaveChanges();
            return View("/Views/Customer/Login.cshtml");
        }
    }
}