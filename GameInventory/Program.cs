using GameInventory;

Console.WriteLine("=== ТЕСТ СОЗДАНИЯ ПРЕДМЕТОВ ===");

// 1. Создаем простое оружие
Console.WriteLine("\n1. Создание базового оружия:");
var basicWeapon = new BasicWeaponBuilder("Деревянный меч").Build();
basicWeapon.PrintInfo();

// 2. Создаем улучшенное оружие
Console.WriteLine("\n2. Создание улучшенного оружия:");
var improvedWeapon = new ImprovedWeaponBuilder("Стальной меч").Build();
improvedWeapon.PrintInfo();

// 3. Создаем броню
Console.WriteLine("\n3. Создание брони:");
var armor = new ArmorBuilder()
    .SetName("Железная кираса")
    .SetCost(200)
    .SetCount(1)
    .SetDefense(50)
    .SetDurability(150)
    .Build();
armor.PrintInfo();

// 4. Создаем зелье
Console.WriteLine("\n4. Создание зелья:");
var potion = new PotionBuilder()
    .SetName("Зелье лечения")
    .SetCost(30)
    .SetCount(3)
    .SetHealthRestore(40)
    .Build();
potion.PrintInfo();

Console.WriteLine("\n=== ТЕСТ СОЗДАНИЯ ИГРОКА И ПРИОБРЕТЕНИЯ ПРЕДМЕТОВ ===");

// 5. Создаем базового игрока
Console.WriteLine("\n5. Создание базового игрока:");
var basicBuilder = new BasicPlayerBuilder("Карина");
var basicPlayer = basicBuilder.Build();
basicPlayer.PrintPlayerInfo();

// 6. Покупаем предметы
Console.WriteLine("\n6. Покупка деревянного меча:");
basicPlayer.AddNewItem(basicWeapon);

Console.WriteLine("\n7. Покупка стального меча:");
basicPlayer.AddNewItem(improvedWeapon);

Console.WriteLine("\n8. Покупка брони:");
basicPlayer.AddNewItem(armor);

Console.WriteLine("\n9. Покупка зелья:");
basicPlayer.AddNewItem(potion);

// 7. Пытаемся купить что-то без денег
Console.WriteLine("\n10. Попытка купить еще один стальной меч (денег нет):");
basicPlayer.AddNewItem(improvedWeapon);

// 8. Показываем все предметы игрока
Console.WriteLine("\n11. Все предметы игрока:");
basicPlayer.ShowAllItems();

Console.WriteLine("\n=== ТЕСТ ВЫБОРА И ИСПОЛЬЗОВАНИЯ ПРЕДМЕТОВ ===");

// 9. Выбираем предметы
Console.WriteLine("\n12. Выбираем зелье для использования:");
basicPlayer.ChooseItem(potion);

// 10. Показываем выбранные предметы
Console.WriteLine("\n13. Выбранные предметы:");
basicPlayer.ShowChosenItems();

// 11. Используем предмет (нужно добавить метод EffectsOnPlayer в Item)
// basicPlayer.UseChosenItem(potion);

Console.WriteLine("\n=== СРАВНЕНИЕ С УЛУЧШЕННЫМ ИГРОКОМ ===");

// 12. Создаем улучшенного игрока
Console.WriteLine("\n14. Создание улучшенного игрока:");
var improvedBuilder = new ImprovedPlayerBuilder("Вергилий");
var improvedPlayer = improvedBuilder.Build();
improvedPlayer.PrintPlayerInfo();

// 13. Покупаем оружие улучшенным игроком
Console.WriteLine("\n15. Улучшенный игрок покупает стальной меч:");
improvedPlayer.AddNewItem(improvedWeapon);

Console.WriteLine("\n=== ТЕСТ ЗАВЕРШЕН ===");