using Xunit;
using GameInventory;

namespace GameInventoryTests
{
    public class GameIntegrationTests
    {
        // Тест 1: Проверка создания и покупки предметов
        [Fact]
        public void Player_CanPurchaseItems_AndStatsUpdate()
        {
            // Arrange
            var player = new BasicPlayerBuilder("Тестовый игрок").Build();
            var weapon = new BasicWeaponBuilder("Тестовый меч").Build();
            var armor = new BasicArmorBuilder("Тестовая броня").Build();

            int initialBalance = player.Balance;
            int initialStrength = player.Strength;
            int initialHealth = player.Health;

            // Act - покупаем предметы
            player.AddNewItem(weapon); // должно увеличить силу
            player.AddNewItem(armor);  // должно увеличить здоровье

            // Assert
            Assert.True(player.Balance < initialBalance); // деньги потрачены
            Assert.True(player.Strength > initialStrength); // сила увеличилась
            Assert.True(player.Health > initialHealth); // здоровье увеличилось
            Assert.Contains(weapon, player._items); // оружие в инвентаре
            Assert.Contains(armor, player._items); // броня в инвентаре
        }

        // Тест 2: Проверка недостатка средств
        [Fact]
        public void Player_CannotPurchase_WhenInsufficientFunds()
        {
            // Arrange
            var player = new BasicPlayerBuilder("Бедный игрок").Build();

            // Создаем дорогой предмет
            var expensiveWeapon = new WeaponBuilder()
                .SetName("Дорогой меч")
                .SetCost(1000) // дороже, чем баланс игрока (200)
                .SetCount(1)
                .SetDamage(50)
                .SetDurability(100)
                .Build();

            int initialBalance = player.Balance;

            // Act
            player.AddNewItem(expensiveWeapon);

            // Assert
            Assert.Equal(initialBalance, player.Balance); // баланс не изменился
            Assert.DoesNotContain(expensiveWeapon, player._items); // предмет не добавлен
        }

        // Тест 3: Проверка выбора и использования предметов
        [Fact]
        public void Player_CanChooseAndUseItems()
        {
            // Arrange
            var player = new BasicPlayerBuilder("Игрок").Build();
            var potion = new BasicPotionBuilder("Зелье лечения").Build();

            // Добавляем зелье в инвентарь
            player.AddNewItem(potion);
            int initialPotionCount = potion.Count;

            // Act
            player.ChooseItem(potion); // выбираем зелье
            player.UseChosenItem(potion); // используем зелье

            // Assert
            Assert.Contains(potion, player._chosenItems); // зелье в выбранных
            Assert.Equal(initialPotionCount - 1, potion.Count); // количество уменьшилось
            Assert.True(player.Health > 0); // здоровье восстановлено
        }

        // Тест 4: Проверка разных типов предметов
        [Fact]
        public void DifferentItemTypes_HaveDifferentEffects()
        {
            // Arrange
            var player = new BasicPlayerBuilder("Игрок").Build();

            // Создаем предметы разных типов
            var weapon = new BasicWeaponBuilder("Меч").Build();
            var armor = new BasicArmorBuilder("Броня").Build();
            var potion = new BasicPotionBuilder("Зелье").Build();
            var questItem = new KeyItemBuilder("Ключ", "Тестовый квест").Build();

            int initialStrength = player.Strength;
            int initialHealth = player.Health;

            // Act - добавляем все предметы
            player.AddNewItem(weapon);
            player.AddNewItem(armor);
            player.AddNewItem(potion);
            player.AddNewItem(questItem); // квестовый предмет

            // Assert - проверяем типы предметов
            Assert.Equal(ItemType.WEAPON, weapon.Type);
            Assert.Equal(ItemType.ARMOR, armor.Type);
            Assert.Equal(ItemType.POTION, potion.Type);
            Assert.Equal(ItemType.QUEST, questItem.Type);

            // Проверяем эффекты
            Assert.True(player.Strength > initialStrength); // оружие дало силу
            Assert.True(player.Health > initialHealth); // броня/зелье дали здоровье

            // Проверяем, что все предметы в инвентаре
            Assert.Equal(4, player._items.Count);
        }
    }
}