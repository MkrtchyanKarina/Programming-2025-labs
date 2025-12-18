namespace GameInventory
{
    public class Armor : Item
    {
        public int Defense { get; set; }
        public int Durability { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"   Защита: {Defense} | Прочность: {Durability}");
        }

        public override void improvePlayerStats(Player player)
        {
            player.Health += this.Defense;
            Console.WriteLine($"Здоровье игрока увеличено на {this.Defense}");
        }
    }

    public class ArmorBuilder : ItemBuilder<ArmorBuilder>
    {
        protected int defense;
        protected int durability;

        public ArmorBuilder SetDefense(int defense)
        {
            this.defense = defense;
            return this;
        }

        public ArmorBuilder SetDurability(int durability)
        {
            this.durability = durability;
            return this;
        }

        public override Item Build()
        {
            return new Armor
            {
                Type = ItemType.ARMOR,
                Name = item.Name,
                Cost = item.Cost,
                Count = item.Count,
                Description = item.Description,
                Defense = this.defense,
                Durability = this.durability
            };
        }
    }

    // Базовая броня
    public class BasicArmorBuilder : ArmorBuilder
    {
        public BasicArmorBuilder(string name)
        {
            SetName(name);
            SetCost(100);
            SetCount(1);
            SetDefense(20);
            SetDurability(150);
            SetDescription("Простая броня для защиты");
        }
    }

    // Улучшенная броня
    public class ImprovedArmorBuilder : ArmorBuilder
    {
        public ImprovedArmorBuilder(string name)
        {
            SetName(name);
            SetCost(400);
            SetCount(1);
            SetDefense(50);
            SetDurability(300);
            SetDescription("Прочная улучшенная броня");
        }
    }

    // Магическая броня
    public class MagicalArmorBuilder : ArmorBuilder
    {
        public MagicalArmorBuilder(string name)
        {
            SetName(name);
            SetCost(800);
            SetCount(1);
            SetDefense(80);
            SetDurability(200);
            SetDescription("Магическая броня с особыми свойствами");
        }
    }
}