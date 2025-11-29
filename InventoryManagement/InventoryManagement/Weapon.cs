using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    internal class Weapon: Item
    {
        private int _max_strength;
        private int _current_strength;
        private int _cast_time;
        private int _cooldown_time;
        internal Weapon(string name, string description, int weight, int cost, int count, 
            int max_strength, int current_strength, int cast_time, int cooldown_time): base( name,  description,  weight,  cost,  count)
        { 
       }
    }
}
