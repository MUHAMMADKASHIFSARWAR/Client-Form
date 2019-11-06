using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace clientForm
{
    public class MailMessageModel
    {
        public string userid { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string urlAttachment { get; set; }

        public MailMessage mailMessage { get; set; }
    }
}