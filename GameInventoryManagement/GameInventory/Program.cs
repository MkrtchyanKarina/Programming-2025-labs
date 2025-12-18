using GameInventory;


// 1. Разные уровни оружия
Console.WriteLine("\n1. Оружие разного уровня:");
var basicWeapon = new BasicWeaponBuilder("Деревянный меч").Build();
var improvedWeapon = new ImprovedWeaponBuilder("Стальной меч").Build();
var legendaryWeapon = new LegendaryWeaponBuilder("Ямато").Build();

basicWeapon.PrintInfo();
improvedWeapon.PrintInfo();
legendaryWeapon.PrintInfo();

// 2. Разные уровни брони
Console.WriteLine("\n2. Броня разного уровня:");
var leatherArmor = new BasicArmorBuilder("Кожаная броня").Build();
var steelArmor = new ImprovedArmorBuilder("Стальная кираса").Build();
var magicArmor = new MagicalArmorBuilder("Мантия мага").Build();

leatherArmor.PrintInfo();
steelArmor.PrintInfo();
magicArmor.PrintInfo();

// 3. Разные уровни зелий
Console.WriteLine("\n3. Зелья разного уровня:");
var healthPotion = new BasicPotionBuilder("Зелье лечения").Build();
var manaPotion = new ImprovedPotionBuilder("Зелье маны").Build();
var elixir = new ElixirBuilder("Эликсир бессмертия").Build();

healthPotion.PrintInfo();
manaPotion.PrintInfo();
elixir.PrintInfo();

// 4. Квестовые предметы
Console.WriteLine("\n4. Квестовые предметы:");
var key = new KeyItemBuilder("Ржавый ключ", "Найти сокровище").Build();
var artifact = new ArtifactBuilder("Кристалл силы", "Восстановить кристалл").Build();
var letter = new QuestItemBuilder()
    .SetName("Запечатанное письмо")
    .SetDescription("Письмо от короля с секретным заданием")
    .SetQuestName("Доставить послание")
    .SetCost(0)
    .SetCount(1)
    .Build();

key.PrintInfo();
artifact.PrintInfo();
letter.PrintInfo();


// 5. Создаем игрока
var playerBuilder = new BasicPlayerBuilder("Карина");
var player = playerBuilder.Build();
player.PrintPlayerInfo();

// 6. Покупаем предметы разных типов
Console.WriteLine("\nПокупка базового оружия:");
player.AddNewItem(basicWeapon);

Console.WriteLine("\nПокупка улучшенной брони:");
player.AddNewItem(steelArmor);

Console.WriteLine("\nПокупка зелья:");
player.AddNewItem(healthPotion);

// 7. Получаем квестовые предметы (они бесплатные)
Console.WriteLine("\nПолучение квестового предмета:");
player.AddNewItem(key);

// 8. Пытаемся купить легендарное оружие (дорого!)
Console.WriteLine("\nПопытка купить легендарное оружие:");
player.AddNewItem(legendaryWeapon);

// 9. Показываем все предметы
Console.WriteLine("\nВсе предметы игрока:");
player.ShowAllItems();

// 10. Выбираем предметы для использования
Console.WriteLine("\nВыбираем зелье и ключ:");
player.ChooseItem(healthPotion);
player.ChooseItem(key);

Console.WriteLine("\nВыбранные предметы:");
player.ShowChosenItems();

// 11. Используем зелье
Console.WriteLine("\nИспользуем зелье лечения:");
player.UseChosenItem(healthPotion);
player.PrintPlayerInfo();

