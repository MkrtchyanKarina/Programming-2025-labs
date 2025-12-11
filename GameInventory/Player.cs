using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInventory
{

    internal class Player
    {
        internal string Name { get; set; }
        internal int Balance { get; set; }

        internal int Strength { get; set; }
        internal int Intelligence { get; set; }
        internal int Health { get; set; }

        internal List<Item> _items = new List<Item>();
        internal List<Item> _chosenItems = new List<Item>();

        internal void PrintPlayerInfo()
        {
            Console.WriteLine($"Имя:{Name} Баланс:{Balance} Сила:{Strength} Интеллект:{Intelligence} Здоровье:{Health}");
        }

        internal void AddNewItem(Item item)
        {
            if (Balance - item.Cost >= 0)
            {
                var existingItem = _items.FirstOrDefault(i => i.Name == item.Name);

                if (existingItem != null)
                {
                    existingItem.Count += 1;
                }
                else
                {
                    _items.Add(item);
                    item.Count = 1;
                }
                Balance -= item.Cost;
                Console.WriteLine("Приобретен новый элемент");
                item.improvePlayerStats(this);
                this.PrintPlayerInfo();
            }
            else
            {
                Console.WriteLine("Недостаточно средств");
            }
        }

        internal void ChooseItem(Item item)
        {
            _chosenItems.Add(item);
        }
        internal void UseChosenItem(Item item)
        {
            item.Count -= 1;
            item.improvePlayerStats(this);
        }
        internal void DeleteChosenItem(Item item)
        {
            _chosenItems.Remove(item);
        }



        internal void ShowAllItems()
        {
            foreach (Item item in _items)
            {
                Console.WriteLine($"{item.Name}");
            }
        }

        internal void ShowChosenItems()
        {
            foreach (Item item in _chosenItems)
            {
                Console.WriteLine($"{item.Name}");
            }
        }
    }


}
