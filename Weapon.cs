using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{

    public class Weapon
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int Durability { get; set; }
        public CharacterClass Class { get; set; }

        public Weapon(string name, int power, int durability, CharacterClass characterClass)
        {
            if (power < 1)
                throw new ArgumentException("The weapon's power cannot be less than 1.");
        }
        public void ReduceDurability()
        {
            Durability--;
        }
    }
}
