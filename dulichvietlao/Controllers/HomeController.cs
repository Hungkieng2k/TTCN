using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Dulichvietlao.Models.Db;
using Dulichvietlao.Models.ViewModels;
using Dulichvietlao.Services;

namespace Dulichvietlao.Controllers
{
    //public class BaseController : Controller
    //{
    //    public override void OnActionExecuted(ActionExecutedContext context)
    //    {
    //        base.OnActionExecuted(context);
    //        var session = HttpContext.Session;
    //        ViewData["Session"] = session.GetString("Username");
    //    }
    //}
    public class HomeController : Controller
    {
        private readonly DulichvietlaoContext _db;
        private readonly MemberService _memberService;
        public HomeController(DulichvietlaoContext db, MemberService memberService)
        {
            this._db = db;
            this._memberService = memberService;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            if (this._memberService.LoginMember(Username, Password) == true)
            {
                HttpContext.Session.SetString("Username",Username);
                return RedirectToAction("Index", "Home");
            }
            string error = "Tài khoản hoặc mật khẩu không đúng!!!";
            ViewBag.Error = error;
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(MemberViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                this._memberService.SaveInfoMember(viewModel);
                return RedirectToAction("Login");
            }

            string error = "Đăng kí không thành công";
            ViewBag.Error = error;
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index");
        }
    }
}
