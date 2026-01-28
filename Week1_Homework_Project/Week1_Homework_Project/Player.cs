using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_Homework_Project
{
    public class Player : Character
    {
        public int Speed { get; set; }

        public Player(string name, int health, int speed)
            : base(name, health)
        {
            Speed = speed;
        }

        public void Attack()
        {
            Console.WriteLine($"{Name} attacks at a speed of {Speed} mph!");
        }
    }
}
