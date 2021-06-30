namespace ChefByStep.Models
{
    public class Step : BaseModel
    {
        public int Id { get; set; }

        public string Instruction { get; set; }

        public int DurationMin { get; set; }

        public bool isDone { get; set; }

        public int NumberOfStep { get; set; }
    }
}