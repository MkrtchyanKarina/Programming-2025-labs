using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInventory
{
    internal class Weapon : Item
    {
        internal int Durability { get; set; }

        internal override void improvePlayerStats(Player player)
        {
            player.Strength += this.Durability;
            Console.WriteLine($"Сила игрока увеличена на {this.Durability}");
        }
    }

    // Изменено: Наследуемся от ItemBuilder<WeaponBuilder>
    internal class WeaponBuilder : ItemBuilder<WeaponBuilder>
    {
        private int durability;

        internal WeaponBuilder SetDurability(int durability)
        {
            this.durability = durability;
            return this; // Возвращаем WeaponBuilder
        }

        internal override Item Build()
        {
            var weapon = new Weapon
            {
                Type = ItemType.WEAPON,
                Name = item.Name,
                Cost = item.Cost,
                Count = item.Count,
                Durability = this.durability
            };
            return weapon;
        }
    }

    internal class BasicWeaponBuilder : WeaponBuilder
    {
        internal BasicWeaponBuilder(string name)
        {
            SetName(name);
            SetCost(50);
            SetCount(1);
            SetDurability(100);
        }
    }

    internal class ImprovedWeaponBuilder : WeaponBuilder
    {
        internal ImprovedWeaponBuilder(string name)
        {
            SetName(name);
            SetCost(300);
            SetCount(1);
            SetDurability(300);
        }
    }
}
