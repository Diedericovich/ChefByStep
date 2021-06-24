using ChefByStep.ASP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Services
{
    public class ActiveUserService
    {
        private readonly IUserService _service;
        public ApiUser CurrentUser { get; set; }

        public ActiveUserService(IUserService service)
        {
            _service = service;
            GetUser().Wait();
        }

        private async Task GetUser()
        {
        }
    }
}