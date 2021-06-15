using ChefByStep.API;
using ChefByStep.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbSeeder
{
    internal class Seeder
    {
        private DatabaseContext _context;

        public Seeder()
        {
        }

        public Seeder(DatabaseContext context)
        {
            _context = context;
        }

        public void test()
        {
            User test = new User
            {
                Name = "seeder",
            };
            _context.Add(test);
            _context.SaveChanges();
        }
    }
}