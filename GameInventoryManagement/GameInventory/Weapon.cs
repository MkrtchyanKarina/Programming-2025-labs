namespace GameInventory
{
    public class Weapon : Item
    {
        public int Durability { get; set; }
        public int Damage { get; set; } // Добавили урон

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"   Прочность: {Durability} | Урон: {Damage}");
        }

        public override void improvePlayerStats(Player player)
        {
            player.Strength += this.Damage; // Теперь сила увеличивается на урон
            Console.WriteLine($"Сила игрока увеличена на {this.Damage}");
        }
    }

    public class WeaponBuilder : ItemBuilder<WeaponBuilder>
    {
        protected int durability;
        protected int damage;

        public WeaponBuilder SetDurability(int durability)
        {
            this.durability = durability;
            return this;
        }

        public WeaponBuilder SetDamage(int damage)
        {
            this.damage = damage;
            return this;
        }

        public override Item Build()
        {
            var weapon = new Weapon
            {
                Type = ItemType.WEAPON,
                Name = item.Name,
                Cost = item.Cost,
                Count = item.Count,
                Description = item.Description,
                Durability = this.durability,
                Damage = this.damage
            };
            return weapon;
        }
    }

    // Базовое оружие (упрощенное)
    public class BasicWeaponBuilder : WeaponBuilder
    {
        public BasicWeaponBuilder(string name)
        {
            SetName(name);
            SetCost(50);
            SetCount(1);
            SetDurability(100);
            SetDamage(10);
            SetDescription("Простое базовое оружие для новичков");
        }
    }

    // Улучшенное оружие
    public class ImprovedWeaponBuilder : WeaponBuilder
    {
        public ImprovedWeaponBuilder(string name)
        {
            SetName(name);
            SetCost(300);
            SetCount(1);
            SetDurability(300);
            SetDamage(25);
            SetDescription("Мощное улучшенное оружие с высокой прочностью");
        }
    }

    // Легендарное оружие
    public class LegendaryWeaponBuilder : WeaponBuilder
    {
        public LegendaryWeaponBuilder(string name)
        {
            SetName(name);
            SetCost(1000);
            SetCount(1);
            SetDurability(500);
            SetDamage(50);
            SetDescription("Легендарное оружие с уникальными свойствами");
        }
    }
}