using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InventoryManagement
{
    internal abstract class Item
    {
        private string _name;
        private int _weight;
        private int _cost;
        private int _count;
        internal Item(string name, string description, int weight, int cost, int count)
        {
            Name = name;
            Description = description;
            Weight = weight;
            Count = count;
        }

        internal string Name
        {
            get { return _name; }

            set { ArgumentsCheck.StringIsNotEmptyCheck(value, nameof(Name)); }
        }

        internal string Description { get; set; }

        internal int Weight
        {
            get { return _weight; }

            set { ArgumentsCheck.GreaterThanZeroCheck(value, nameof(Weight)); }
        }

        internal int Cost
        {
            get { return _cost; }

            set { ArgumentsCheck.GreaterThanZeroCheck(value, nameof(Cost)); }
            
        }

        internal int Count
        {
            get { return _count; }

            set { ArgumentsCheck.GreaterThanZeroCheck(value, nameof(Count)); }
        }
    }
}
