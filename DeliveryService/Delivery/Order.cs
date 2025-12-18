namespace delivery
{
    public class Order
    {
        private AbstractCuisineFactory _factory;
        private Dictionary<Dish, int> _selectedMainCourses = new Dictionary<Dish, int>();
        private Dictionary<Dish, int> _selectedAppetizers = new Dictionary<Dish, int>();
        private Dictionary<Dish, int> _selectedDesserts = new Dictionary<Dish, int>();

        public bool Urgency { get; set; }
        public string PersonalPreferences { get; set; }
        public IOrderState State { get; set; } // order status: accepted, in progress, ready
        private IPricingStrategy _pricingStrategy;

        public decimal TotalCost { get; set; } = 0.0m;

        public Order(AbstractCuisineFactory factory)
        {
            _factory = factory;
            State = new AcceptedOrderState();
            _pricingStrategy = new StandardPricing();
        }

        public void ChangeCuisine(AbstractCuisineFactory newFactory)
        {
            _factory = newFactory;
        }

        public void SelectMainCourse()
        {
            var mainCourse = _factory.CreateMainCourse();
            var existingDish = _selectedMainCourses.Keys.FirstOrDefault(d => d.Name == mainCourse.Name);

            if (existingDish != null)
                _selectedMainCourses[existingDish] += 1;
            else
                _selectedMainCourses[mainCourse] = 1;
        }

        public void SelectAppetizer()
        {
            var appetizer = _factory.CreateAppetizer();
            var existingDish = _selectedAppetizers.Keys.FirstOrDefault(d => d.Name == appetizer.Name);

            if (existingDish != null)
                _selectedAppetizers[existingDish] += 1;
            else
                _selectedAppetizers[appetizer] = 1;
        }

        public void SelectDessert()
        {
            var dessert = _factory.CreateDessert();
            var existingDish = _selectedDesserts.Keys.FirstOrDefault(d => d.Name == dessert.Name);

            if (existingDish != null)
                _selectedDesserts[existingDish] += 1;
            else
                _selectedDesserts[dessert] = 1;
        }

        public void ShowOrder()
        {
            Console.WriteLine("=== ВАШ ИНДИВИДУАЛЬНЫЙ ЗАКАЗ ===");
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

        public decimal GetBaseCost()
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

        public void SetPricingStrategy(IPricingStrategy strategy)
        {
            _pricingStrategy = strategy;
        }

        public decimal CalculateTotalPrice()
        {
            TotalCost = _pricingStrategy.CalculatePrice(this);
            return TotalCost;
        }

        public void ShowOrderWithTotal()
        {
            ShowOrder();
            decimal total = CalculateTotalPrice();
            Console.WriteLine($"\n{_pricingStrategy.GetDescription()}");
            Console.WriteLine($"ИТОГО: {total:F2} руб.");
        }



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