using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dulichvietlao.Models.Commands
{
    public class Email
    {
        public string Title { get; set; }
        public string ToMail { get; set; }
        public string FromEmail { get; set; }
        public string Password { get; set; }
        public string Content { get; set; }
        public Email()
        {

        }
        public Email(string Title,string ToMail,string FromEmail,string Password,string Content)
        {
            this.Title = Title;
            this.ToMail = ToMail;
            this.FromEmail = FromEmail;
            this.Password = Password;
            this.Content = Content;
        }
    }
}
