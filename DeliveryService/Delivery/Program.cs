using delivery;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Сервис доставки еды");

        // Создаем фасад для работы со всей системой
        var deliverySystem = new DeliverySystemFacade();

        // Пример
        Console.WriteLine("Простой заказ итальянской кухни");

        // Смотрим меню
        deliverySystem.ShowMenu("итальянская");

        // Создаем заказ
        Order order1 = deliverySystem.CreateOrder(
            cuisineType: "итальянская",
            urgency: false,
            personalPreferences: "",
            addAppetizer: true,
            addMainCourse: true,
            addDessert: false
        );

        // Добавляем еще десерт
        Console.WriteLine("Добавляем десерт в заказ...");
        order1.SelectDessert();

        // Показываем заказ с разными расчетами
        Console.WriteLine("РАСЧЕТ СТОИМОСТИ:");
        deliverySystem.ShowOrderWithCalculation(order1); // Стандартный
        deliverySystem.ShowOrderWithCalculation(order1, 15); // Со скидкой 15%

        // Обрабатываем жизненный цикл заказа
        deliverySystem.ProcessOrderLifecycle(order1);

    }
}



