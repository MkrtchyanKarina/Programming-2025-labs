using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    internal abstract class Weapon 
    {
        private int _max_strength;
        private int _current_strength;
        private int _cast_time;
        private int _cooldown_time;
        internal Weapon(int max_strength, int current_strength, int cast_time, int cooldown_time) { 
       }
    }
}
