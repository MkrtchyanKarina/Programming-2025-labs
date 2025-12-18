namespace delivery
{
    // Интерфейс строителя
    public interface IOrderBuilder
    {
        void CreateOrder();
        void SetFastDelivery(bool fastDelivery);
        void SetPersonalPreferences(string personalPreferences);
        Order GetOrder();
    }

    // Конкретный строитель
    public class OrderBuilder : IOrderBuilder
    {
        private AbstractCuisineFactory _factory;
        private Order _order;

        public OrderBuilder(AbstractCuisineFactory factory)
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


    public class Director
    {
        public void CreateRegularOrder(IOrderBuilder builder)
        {
            builder.CreateOrder();
            builder.SetFastDelivery(false);
            builder.SetPersonalPreferences("");
        }

        public void CreateUrgentOrder(IOrderBuilder builder)
        {
            builder.CreateOrder();
            builder.SetFastDelivery(true);
            builder.SetPersonalPreferences("");
        }

        public void CreateSpecialOrder(IOrderBuilder builder)
        {
            builder.CreateOrder();
            builder.SetFastDelivery(false);
            builder.SetPersonalPreferences("Есть дополнительные пожелания к заказу!");
        }

        public void CreateSpecialUrgentOrder(IOrderBuilder builder)
        {
            builder.CreateOrder();
            builder.SetFastDelivery(true);
            builder.SetPersonalPreferences("Есть дополнительные пожелания к заказу!");
        }

    }
}