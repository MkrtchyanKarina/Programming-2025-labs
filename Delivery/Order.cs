namespace delivery
{
    internal class Order
    {
        private readonly AbstractCuisineFactory _factory;
        private Dish _selectedMainCourse;
        private Dish _selectedAppetizer;
        private Dish _selectedDessert;

        internal bool Urgency { get; set; }
        internal string PersonalPreferences { get; set; }

        internal Order(AbstractCuisineFactory factory)
        {
            _factory = factory;
        }

        public void SelectMainCourse()
        {
            _selectedMainCourse = _factory.CreateMainCourse();
        }

        public void SelectAppetizer()
        {
            _selectedAppetizer = _factory.CreateAppetizer();
        }

        public void SelectDessert()
        {
            _selectedDessert = _factory.CreateDessert();
        }

        public void ShowOrder()
        {
            Console.WriteLine("=== ВАШ ИНДИВИДУАЛЬНЫЙ ЗАКАЗ ===");
            decimal total = 0;

            if (_selectedAppetizer != null)
            {
                _selectedAppetizer.PrintInfo();
                total += _selectedAppetizer.Cost;
            }

            if (_selectedMainCourse != null)
            {
                _selectedMainCourse.PrintInfo();
                total += _selectedMainCourse.Cost;
            }

            if (_selectedDessert != null)
            {
                _selectedDessert.PrintInfo();
                total += _selectedDessert.Cost;
            }

            Console.WriteLine($"\nИтого к оплате: {total} руб.");
        }
    }



    // Интерфейс строителя
    internal interface IOrderBuilder
    {
        void CreateOrder();
        void SetFastDelivery(bool fastDelivery);
        void SetPersonalPreferences(string personalPreferences);
        Order GetOrder();
    }

    // Конкретный строитель
    internal class OrderBuilder : IOrderBuilder
    {
        private AbstractCuisineFactory _factory; // Убрал internal и изменил доступ
        private Order _order;

        internal OrderBuilder(AbstractCuisineFactory factory)
        {
            _factory = factory;
        }

        public void CreateOrder()
        {
            _order = new Order(_factory); // Используем фабрику для создания Order
        }
        public void SetFastDelivery(bool urgency) => _order.Urgency = urgency;
        public void SetPersonalPreferences(string personalPreferences) => _order.PersonalPreferences = personalPreferences;
        public Order GetOrder() => _order;
    }


    internal class Director
    {
        internal void CreateRegularOrder(IOrderBuilder builder)
        {
            builder.CreateOrder();
            builder.SetFastDelivery(false);
            builder.SetPersonalPreferences("");
        }

        internal void CreateUrgentOrder(IOrderBuilder builder)
        {
            builder.CreateOrder();
            builder.SetFastDelivery(true);
            builder.SetPersonalPreferences("");
        }

        internal void CreateSpecialOrder(IOrderBuilder builder)
        {
            builder.CreateOrder();
            builder.SetFastDelivery(false);
            builder.SetPersonalPreferences("Есть дополнительные пожелания к заказу!");
        }

        internal void CreateSpecialUrgentOrder(IOrderBuilder builder)
        {
            builder.CreateOrder();
            builder.SetFastDelivery(true);
            builder.SetPersonalPreferences("Есть дополнительные пожелания к заказу!");
        }

    }

}