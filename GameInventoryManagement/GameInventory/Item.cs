namespace GameInventory
{
    public enum ItemType
    {
        WEAPON,
        ARMOR,
        POTION,
        QUEST // Добавили новый тип
    }

    public class Item
    {
        public ItemType Type { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Count { get; set; }
        public string Description { get; set; } = ""; // Добавили описание

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Предмет: {Name} | Тип: {Type} | Цена: {Cost} | Количество: {Count}");
            if (!string.IsNullOrEmpty(Description))
            {
                Console.WriteLine($"   Описание: {Description}");
            }
        }

        public virtual void improvePlayerStats(Player player)
        {
            Console.WriteLine("Улучшены статы");
        }
    }

    // Класс для квестовых предметов
    public class QuestItem : Item
    {
        public string QuestName { get; set; } = "";
        public bool IsCompleted { get; set; } = false;

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"   Квест: {QuestName} | Статус: {(IsCompleted ? "Выполнен" : "Не выполнен")}");
        }

        public override void improvePlayerStats(Player player)
        {
            // Квестовые предметы обычно не улучшают статы
            Console.WriteLine($"Квестовый предмет '{Name}' не дает статов");
        }
    }

    public abstract class ItemBuilder<T> where T : ItemBuilder<T>
    {
        protected Item item = new Item();

        public T SetName(string name)
        {
            item.Name = name;
            return (T)this;
        }

        public T SetCost(int cost)
        {
            item.Cost = cost;
            return (T)this;
        }

        public T SetCount(int count)
        {
            item.Count = count;
            return (T)this;
        }

        public T SetDescription(string description)
        {
            item.Description = description;
            return (T)this;
        }

        public abstract Item Build();
    }
}