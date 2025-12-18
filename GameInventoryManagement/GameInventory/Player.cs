using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInventory
{

    public class Player
    {
        public string Name { get; set; }
        public int Balance { get; set; }

        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Health { get; set; }

        public List<Item> _items = new List<Item>();
        public List<Item> _chosenItems = new List<Item>();

        public void PrintPlayerInfo()
        {
            Console.WriteLine($"Имя:{Name} Баланс:{Balance} Сила:{Strength} Интеллект:{Intelligence} Здоровье:{Health}");
        }

        public void AddNewItem(Item item)
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

        public void ChooseItem(Item item)
        {
            _chosenItems.Add(item);
        }
        public void UseChosenItem(Item item)
        {
            item.Count -= 1;
            item.improvePlayerStats(this);
        }
        public void DeleteChosenItem(Item item)
        {
            _chosenItems.Remove(item);
        }



        public void ShowAllItems()
        {
            foreach (Item item in _items)
            {
                Console.WriteLine($"{item.Name}");
            }
        }

        public void ShowChosenItems()
        {
            foreach (Item item in _chosenItems)
            {
                Console.WriteLine($"{item.Name}");
            }
        }
    }


}
