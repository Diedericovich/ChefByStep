namespace ChefByStep.API.Entities.DTOs
{
    public class StepDto
    {
        public int Id { get; set; }

        public string Instruction { get; set; }

        public int DurationMin { get; set; }

        public bool IsDone { get; set; }

        public int RecipeId { get; set; }
    }
}