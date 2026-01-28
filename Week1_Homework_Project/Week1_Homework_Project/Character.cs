using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_Homework_Project
{
    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }


        public Character(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{Name} has {Health} health.");
        }
    }
}
