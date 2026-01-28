using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_Homework_Project
{
    public class Villain : Character
    {
        public string VillainType { get; set; }

        public Villain(string name,int health, string villainType)
            : base(name, health)
        {
            VillainType = villainType;
        }

        public void Taunt()
        {
            Console.WriteLine($"{VillainType} {Name} taunts you!");
        }
    }
}
