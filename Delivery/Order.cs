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
        internal IOrderState State { get; set; } // order status: accepted, in progress, ready

        internal Order(AbstractCuisineFactory factory)
        {
            _factory = factory;
            State = new AcceptedOrderState();
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
            Console.WriteLine("=== ¬¿ÿ »Õƒ»¬»ƒ”¿À‹Õ€… «¿ ¿« ===");
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

            Console.WriteLine($"\n»ÚÓ„Ó Í ÓÔÎ‡ÚÂ: {total} Û·.");
        }

        internal void StartDoingOrder()
        {
            State.StartOrder(this);
        }

        internal void FinishDoingOrder()
        {
            State.FinishOrder(this);
        }
    }

}