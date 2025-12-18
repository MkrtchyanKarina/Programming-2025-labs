using delivery;
class Program
{
    static void Main(string[] args)
    {
        //Menu menu = new Menu();
        //Calculator calculator = new Calculator();
        //Conditions condition = new Conditions();

        //OrderFacade order = new OrderFacade(menu, calculator, condition);

        //Custumer custumer = new Custumer();
        //custumer.CreateOrder(order);


        Console.WriteLine("=== СИСТЕМА ЗАКАЗОВ РЕСТОРАНА ===\n");

      
        Console.WriteLine("Пример 1: Стандартный сет");

        AbstractCuisineFactory factory;

        // Выбор кухни
        string selectedCuisine = "Italian"; // Можно изменить на "Chinese"

        // паттерн выбора фабрики
        factory = selectedCuisine == "Italian"
            ? new ItalianCuisineFactory()
            : new ChineseCuisineFactory();

        // Создаем заказ, передавая фабрику в конструктор
        var director = new Director();
        var builder = new OrderBuilder(factory);
        director.CreateSpecialOrder(builder);
        Order special_order = builder.GetOrder();
        Console.WriteLine($"Характеристики заказа: срочность: {special_order.Urgency} | особенности: { special_order.PersonalPreferences}");

        special_order.StartDoingOrder();
        special_order.FinishDoingOrder();

        special_order.ShowOrder();

    }
}

