using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInventory
{
    internal class Potion : Item
    {
        internal int HealthRestore { get; set; }

        internal override void improvePlayerStats(Player player)
        {
            player.Health += this.HealthRestore;
            Console.WriteLine($"Здоровье игрока восстановлено на {this.HealthRestore}");
        }
    }

    // Изменено: Наследуемся от ItemBuilder<PotionBuilder>
    internal class PotionBuilder : ItemBuilder<PotionBuilder>
    {
        private int healthRestore;

        internal PotionBuilder SetHealthRestore(int health)
        {
            this.healthRestore = health;
            return this; // Возвращаем PotionBuilder
        }

        internal override Item Build()
        {
            return new Potion
            {
                Type = ItemType.POTION,
                Name = item.Name,
                Cost = item.Cost,
                Count = item.Count,
                HealthRestore = this.healthRestore
            };
        }
    }
}
