using System;
using System.Collections.Generic;
using System.Text;

namespace ChefByStep.Models
{
    public class ActiveUser
    {
        public User ApplicationUser { get; set; }
        private static ActiveUser Instance { get; set; }

        private ActiveUser() { }

        public static ActiveUser GetInstance()
        {
            return Instance ?? (Instance = new ActiveUser());
        }
    }
}
