using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Models
{
    public class Step : BaseModel
    {
        [DisplayName("Instructions: ")]
        public string Instruction { get; set; }
        public int DurationMin { get; set; }
        public bool IsDone { get; set; }
    }
}