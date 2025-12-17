using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInventory
{
    internal class Armor : Item
    {
        internal int Defense { get; set; }
        internal int Durability { get; set; }

        internal override void improvePlayerStats(Player player)
        {
            player.Health += this.Defense;
            Console.WriteLine($"Здоровье игрока увеличено на {this.Defense}");
        }
    }

    // Изменено: Наследуемся от ItemBuilder<ArmorBuilder>
    internal class ArmorBuilder : ItemBuilder<ArmorBuilder>
    {
        private int defense;
        private int durability;

        internal ArmorBuilder SetDefense(int defense)
        {
            this.defense = defense;
            return this; // Возвращаем ArmorBuilder
        }

        internal ArmorBuilder SetDurability(int durability)
        {
            this.durability = durability;
            return this; // Возвращаем ArmorBuilder
        }

        internal override Item Build()
        {
            return new Armor
            {
                Type = ItemType.ARMOR,
                Name = item.Name,
                Cost = item.Cost,
                Count = item.Count,
                Defense = this.defense,
                Durability = this.durability
            };
        }
    }
}
