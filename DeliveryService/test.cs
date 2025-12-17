//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GameInventory
//{
//    enum ItemType
//    {
//        WEAPON,
//        ARMOR,
//        POTION
//    }

//    protected abstract class AbstractItem
//    { 
//        protected string Name { get; set; }
//        protected ItemType Type { get; set; }
//        protected int Cost { get; set; }
//        protected int Count { get; set; }

//        protected AbstractItem(string name, ItemType type, int cost, int count)
//        { 
//            Name = name;
//            Type = type;
//            Cost = cost;
//            Count = count;
//        }

//        internal void PrintInfo()
//        {
//            Console.WriteLine($"Предмет. Тип: {Type}. Название: {Name}. Цена: {Cost}.");
//        }

//        internal virtual void ImprovePlayerStats(Player player)
//        {
//            Console.WriteLine("Улучшены статы");
//        }
//    }

//    protected abstract class AbstractItemFabric
//    {
//        protected abstract AbstractItem CreateItem();
//    }

//    internal class Weapon : AbstractItem
//    {
//        internal int Durability { get; set; }

//        internal Weapon(int durability) : base(string name, ItemType type, int cost, int count)
//        { 
//            Durability = durability;
//        }

//        internal override void improvePlayerStats(Player player)
//        {
//            player.Strength += this.Durability;
//            Console.WriteLine($"Сила игрока увеличена на {this.Durability}");
//        }
//    }

//    internal class WeaponFabric : AbstractItemFabric
//    {
//        internal override Weapon CreateItem(string name, ItemType type, int cost, int count, int durability)
//        {
//            return new Weapon(name, type, cost, count, durability);
//        }
//    }
//}
