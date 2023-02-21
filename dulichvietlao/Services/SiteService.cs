using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Dulichvietlao.Models.Db;

namespace Dulichvietlao.Services
{
    public class SiteService
    {
        public  string GetTitle() {
            return "Grand Tour Travel Category Flat Bootstrap Responsive Web Template | Home :: w3layouts";
        }

        public  Account GetUserInfo()
        {
            Account acData = null;
            //string data = HttpContext.Session.GetString("Account"); // "1"  data = Session["Account"];
            //if (!string.IsNullOrWhiteSpace(data))
            //{
            //    acData = JsonSerializer.Deserialize<Account>(data);
            
            //}
            return acData;
        }
    }
}
