using ChefByStep.ASP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChefByStep.ASP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
