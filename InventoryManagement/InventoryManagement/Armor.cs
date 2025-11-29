using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    internal class Armor: Item
    {
        internal int CurrentDurability {get; set;}
        internal int MaxDurability { get; set;}
        internal int Strength { get; set; }
        internal int Agility { get; set; }
        internal int Intelligence { get; set; }


        internal Armor(string name, string description, int weight, int cost, int count, int current_durability, int max_durability,
            int strength, int agility, int intelligence): base( name,  description,  weight,  cost,  count)
        {
            CurrentDurability = current_durability;
            MaxDurability = max_durability;
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
        }
    }
}
