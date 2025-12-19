namespace delivery
{
    public class Order
    {
        private AbstractCuisineFactory _factory;
        private Dictionary<Dish, int> _selectedMainCourses = new Dictionary<Dish, int>();  // выбранные основные блюда в заказе
        private Dictionary<Dish, int> _selectedAppetizers = new Dictionary<Dish, int>();  //  выбранные закуски в заказе
        private Dictionary<Dish, int> _selectedDesserts = new Dictionary<Dish, int>();  // выбранные десерты в заказе

        public bool Urgency { get; set; }
        public string PersonalPreferences { get; set; }
        public IOrderState State { get; set; } // статус заказа: accepted, in progress, ready
        private IPricingStrategy _pricingStrategy;  // расчет стоимости заказа

        public decimal TotalCost { get; set; } = 0.0m;  // итоговая стоимость заказа

        public Order(AbstractCuisineFactory factory)
        {
            _factory = factory;  // выбор кухни/меню
            State = new AcceptedOrderState();  // статус заказа
            _pricingStrategy = new StandardPricing();  // способ расчета стоимости
        }

        public void ChangeCuisine(AbstractCuisineFactory newFactory)  // метод для смены меню
        {
            _factory = newFactory;
        }

        public void SelectMainCourse() // добавление основного блюда из выбранной кухни
        {
            var mainCourse = _factory.CreateMainCourse();
            var existingDish = _selectedMainCourses.Keys.FirstOrDefault(d => d.Name == mainCourse.Name);

            if (existingDish != null)
                _selectedMainCourses[existingDish] += 1;
            else
                _selectedMainCourses[mainCourse] = 1;
        }

        public void SelectAppetizer() // добавление закуски из выбранной кухни
        {
            var appetizer = _factory.CreateAppetizer();
            var existingDish = _selectedAppetizers.Keys.FirstOrDefault(d => d.Name == appetizer.Name);

            if (existingDish != null)
                _selectedAppetizers[existingDish] += 1;
            else
                _selectedAppetizers[appetizer] = 1;
        }

        public void SelectDessert() // добавление десерта из выбранной кухни
        {
            var dessert = _factory.CreateDessert();
            var existingDish = _selectedDesserts.Keys.FirstOrDefault(d => d.Name == dessert.Name);

            if (existingDish != null)
                _selectedDesserts[existingDish] += 1;
            else
                _selectedDesserts[dessert] = 1;
        }

        public void ShowOrder()  // вывод информации о выбранных блюдах
        {
            Console.WriteLine("Ваш заказ:");
            decimal total = 0;

            if (_selectedAppetizers.Any())
            {
                foreach (var appetizer in _selectedAppetizers.Keys) 
                {
                    appetizer.PrintInfo();
                    int count = _selectedAppetizers[appetizer];
                    Console.WriteLine($"Количество: {count}. Стоимость {appetizer.Cost * count}");

                }
            }

            if (_selectedDesserts.Any())
            {
                foreach (var dessert in _selectedDesserts.Keys)
                {
                    dessert.PrintInfo();
                    int count = _selectedDesserts[dessert];
                    Console.WriteLine($"Количество: {count}. Стоимость {dessert.Cost * count}");

                }
            }

            if (_selectedMainCourses.Any())
            {
                foreach (var mainCourse in _selectedMainCourses.Keys)
                {
                    mainCourse.PrintInfo();
                    int count = _selectedMainCourses[mainCourse];
                    Console.WriteLine($"Количество: {count}. Стоимость {mainCourse.Cost * count}");
 
                }
            }
            
        }

        public decimal GetBaseCost()  // расчет стоимости выбранных блюд
        {
            decimal total = 0;

            foreach (var item in _selectedAppetizers)
                total += item.Key.Cost * item.Value;

            foreach (var item in _selectedMainCourses)
                total += item.Key.Cost * item.Value;

            foreach (var item in _selectedDesserts)
                total += item.Key.Cost * item.Value;

            return total;
        }

        public void SetPricingStrategy(IPricingStrategy strategy)  // изменение способа расчета финальной стоимости
        {
            _pricingStrategy = strategy;
        }

        public decimal CalculateTotalPrice()  // расчет финальной стоимости
        {
            TotalCost = _pricingStrategy.CalculatePrice(this);
            return TotalCost;
        }

        public void ShowOrderWithTotal()  // вывод финальной стоимости 
        {
            ShowOrder();
            decimal total = CalculateTotalPrice();
            Console.WriteLine($"\n{_pricingStrategy.GetDescription()}");
            Console.WriteLine($"Итого: {total:F2} руб.");
        }

        // методы для изменения статуса заказа

        public void StartDoingOrder()
        {
            State.StartOrder(this);
        }

        public void FinishDoingOrder()
        {
            State.FinishOrder(this);
        }

        public void PrintOrderState()
        {
            State.PrintOrderState();
        }

        
    }

}