using System.Collections.Generic;

namespace ChefByStep.API.Entities
{
    public class Step
    {
        public int Id { get; set; }
        public string Instruction { get; set; }
        public int DurationMin { get; set; }
        public bool IsDone { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}