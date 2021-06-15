using System;
using System.Collections.Generic;
using System.Text;

namespace ChefByStep.Models
{
    public class Step: BaseModel
    {
        public string Instruction { get; set; }
        public int DurationMin { get; set; }
        public bool isDone { get; set; }
    }
}
