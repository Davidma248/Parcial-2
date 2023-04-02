using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    public class Armor
    {
        public string Name { get; set; }
        public int Defense { get; set; }
        public int Durability { get; set; }
        public CharacterClass Class { get; set; }

        
        public Armor(string name, int defense, int durability, CharacterClass characterClass)
        {
            if (defense < 1)
                throw new ArgumentException("The armor's defense cannot be less than 1.");
            Name = name;
            Defense = defense;
            Durability = durability;
            Class = characterClass;
        }

        public void ReduceDurability(int amount)
        {
            Durability -= amount;
        }
    }
}
