using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInventory
{
    enum ItemType
    {
        WEAPON,
        ARMOR,
        POTION
    }

    internal class Item
    {
        internal ItemType Type { get; set; }
        internal string Name { get; set; }
        internal int Cost { get; set; }
        internal int Count { get; set; }

        internal void PrintInfo()
        {
            Console.WriteLine($"Предмет. Тип: {Type}. Название: {Name}. Цена: {Cost}.");
        }

        internal virtual void improvePlayerStats(Player player)
        {
            Console.WriteLine("Улучшены статы");
        }
    }

    // Изменено: Добавлен дженерик T для Fluent Interface
    internal abstract class ItemBuilder<T> where T : ItemBuilder<T>
    {
        protected Item item = new Item();

        // Изменено: Методы возвращают T (конкретный тип билдера)
        internal T SetName(string name)
        {
            item.Name = name;
            return (T)this;
        }

        internal T SetCost(int cost)
        {
            item.Cost = cost;
            return (T)this;
        }

        internal T SetCount(int count)
        {
            item.Count = count;
            return (T)this;
        }

        internal abstract Item Build();
    }



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
}
