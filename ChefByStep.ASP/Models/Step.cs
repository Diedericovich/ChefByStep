namespace ChefByStep.ASP.Models
{
    public class Step : BaseModel
    {
        public string Instruction { get; set; }

        public int DurationMin { get; set; }

        public bool IsDone { get; set; }
    }
}