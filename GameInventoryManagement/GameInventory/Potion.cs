namespace GameInventory
{
    public class Potion : Item
    {
        public int HealthRestore { get; set; }
        public int ManaRestore { get; set; } // Добавили восстановление маны

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"   Восстановление здоровья: {HealthRestore} | Маны: {ManaRestore}");
        }

        public override void improvePlayerStats(Player player)
        {
            player.Health += this.HealthRestore;
            player.Intelligence += this.ManaRestore / 10; // Мана немного увеличивает интеллект
            Console.WriteLine($"Здоровье восстановлено на {this.HealthRestore}, интеллект увеличен на {this.ManaRestore / 10}");
        }
    }

    public class PotionBuilder : ItemBuilder<PotionBuilder>
    {
        protected int healthRestore;
        protected int manaRestore;

        public PotionBuilder SetHealthRestore(int health)
        {
            this.healthRestore = health;
            return this;
        }

        public PotionBuilder SetManaRestore(int mana)
        {
            this.manaRestore = mana;
            return this;
        }

        public override Item Build()
        {
            return new Potion
            {
                Type = ItemType.POTION,
                Name = item.Name,
                Cost = item.Cost,
                Count = item.Count,
                Description = item.Description,
                HealthRestore = this.healthRestore,
                ManaRestore = this.manaRestore
            };
        }
    }

    // Базовое зелье
    public class BasicPotionBuilder : PotionBuilder
    {
        public BasicPotionBuilder(string name)
        {
            SetName(name);
            SetCost(30);
            SetCount(3);
            SetHealthRestore(40);
            SetManaRestore(10);
            SetDescription("Простое зелье для восстановления");
        }
    }

    // Улучшенное зелье
    public class ImprovedPotionBuilder : PotionBuilder
    {
        public ImprovedPotionBuilder(string name)
        {
            SetName(name);
            SetCost(100);
            SetCount(2);
            SetHealthRestore(100);
            SetManaRestore(50);
            SetDescription("Сильное зелье с быстрым эффектом");
        }
    }

    // Эликсир
    public class ElixirBuilder : PotionBuilder
    {
        public ElixirBuilder(string name)
        {
            SetName(name);
            SetCost(250);
            SetCount(1);
            SetHealthRestore(200);
            SetManaRestore(100);
            SetDescription("Мощный эликсир полного восстановления");
        }
    }
}