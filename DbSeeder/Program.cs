using ChefByStep.API;
using System;

namespace DbSeeder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Seeder seed = new Seeder();
            seed.test();
        }
    }
}