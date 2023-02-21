using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dulichvietlao.Services;

namespace Dulichvietlao.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly MemberService _memberService;
        public MenuViewComponent(MemberService memberService)
        {
            this._memberService = memberService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var session = HttpContext.Session;
            ViewData["Session"] = session.GetString("Username");
            ViewBag.Session = ViewData["Session"];
            return View();
        }
        public bool Login(string Username, string Password)
        {
            return this._memberService.LoginMember(Username, Password);
        }
    }
}
