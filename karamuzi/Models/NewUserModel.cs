using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace karamuzi.Models
{
    public class NewUserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}