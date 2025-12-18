namespace delivery
{
    // Фасад для всей системы заказов
    public class DeliverySystemFacade
    {
        private Director _director;

        public DeliverySystemFacade()
        {
            _director = new Director();
        }

        // Основной метод создания заказа
        public Order CreateOrder(string cuisineType, bool urgency, string personalPreferences , bool addAppetizer = true,
                                bool addMainCourse = true, bool addDessert = true)
        {
            // 1. Выбираем фабрику кухни
            AbstractCuisineFactory factory = GetFactoryByCuisine(cuisineType);

            // 2. Создаем строитель
            var builder = new OrderBuilder(factory);

            // 3. Используем директора для создания определенного типа заказа
            if (urgency && personalPreferences != "")
            {
                _director.CreateSpecialUrgentOrder(builder);
            }

            else if (urgency)
            {
                _director.CreateUrgentOrder(builder);
            }
            else if (personalPreferences != "")
            {
                _director.CreateSpecialOrder(builder);
            }
            else 
            {
                _director.CreateRegularOrder(builder);
            }

                // 4. Получаем заказ
                Order order = builder.GetOrder();

                // 5. Добавляем блюда по умолчанию
                if (addAppetizer) order.SelectAppetizer();
                if (addMainCourse) order.SelectMainCourse();
                if (addDessert) order.SelectDessert();

                return order;
            }

        // Метод для расчета стоимости с разными стратегиями
        public void ShowOrderWithCalculation(Order order, decimal discountPercent = 0)
        {
            var strategy = new CombinedPricing(order.Urgency, discountPercent);
            order.SetPricingStrategy(strategy);
            order.ShowOrderWithTotal();
        }

        // Метод для обработки всего жизненного цикла заказа
        public void ProcessOrderLifecycle(Order order)
        {
            Console.WriteLine("ОБРАБОТКА ЗАКАЗА");

            // Показываем текущий статус
            Console.Write("Текущий статус: ");
            order.PrintOrderState();

            // Начинаем готовить
            Console.WriteLine("\n1. Начинаем готовить заказ...");
            order.StartDoingOrder();

            // Показываем статус
            Console.Write("Статус после начала: ");
            order.PrintOrderState();

            // Завершаем заказ
            Console.WriteLine("\n2. Завершаем приготовление...");
            order.FinishDoingOrder();

            // Финальный статус
            Console.Write("Финальный статус: ");
            order.PrintOrderState();

            Console.WriteLine("Заказ обработан!");
        }

        // Метод для смены кухни в заказе
        public void ChangeOrderCuisine(Order order, string newCuisine)
        {
            Console.WriteLine($"\n Меняем кухню на {newCuisine}...");
            order.ChangeCuisine(GetFactoryByCuisine(newCuisine));
        }

        // Вспомогательный метод для получения фабрики
        private AbstractCuisineFactory GetFactoryByCuisine(string cuisineType)
        {
            return cuisineType.ToLower() switch
            {
                "китайская" => new ChineseCuisineFactory(),
                "итальянская" => new ItalianCuisineFactory()
            };
        }

        // Метод для показа меню
        public void ShowMenu(string cuisineType)
        {
            Console.WriteLine($"\n МЕНЮ {cuisineType.ToUpper()} КУХНИ");
            Console.WriteLine(new string('-', 40));

            var factory = GetFactoryByCuisine(cuisineType);

            var appetizer = factory.CreateAppetizer();
            var mainCourse = factory.CreateMainCourse();
            var dessert = factory.CreateDessert();

            Console.WriteLine("Закуски:");
            appetizer.PrintInfo();

            Console.WriteLine("\nОсновные блюда:");
            mainCourse.PrintInfo();

            Console.WriteLine("\nДесерты:");
            dessert.PrintInfo();

            Console.WriteLine(new string('-', 40));
        }
    }
}