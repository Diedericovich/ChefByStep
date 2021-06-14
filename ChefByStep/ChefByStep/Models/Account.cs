using System;
using System.Collections.Generic;
using System.Text;

namespace ChefByStep.Models
{
    public class Account: BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
