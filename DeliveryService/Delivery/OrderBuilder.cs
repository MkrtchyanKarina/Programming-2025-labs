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
            _order = new Order(_factory); // Используем фабрику для создания экземпляра заказа
        }
        // с помощью этих методов устанавливаем значения для полей экземпляра заказа
        public void SetFastDelivery(bool urgency) => _order.Urgency = urgency;
        public void SetPersonalPreferences(string personalPreferences) => _order.PersonalPreferences = personalPreferences;
        public Order GetOrder() => _order;
    }


    public class Director
    {
        public void CreateRegularOrder(IOrderBuilder builder)  // метод для создания обычного заказа
        {
            builder.CreateOrder();
            builder.SetFastDelivery(false);
            builder.SetPersonalPreferences("");
        }

        public void CreateUrgentOrder(IOrderBuilder builder)  // метод для создания срочного заказа
        {
            builder.CreateOrder();
            builder.SetFastDelivery(true);
            builder.SetPersonalPreferences("");
        }

        public void CreateSpecialOrder(IOrderBuilder builder)  // метод для создания особенного заказа
        {
            builder.CreateOrder();
            builder.SetFastDelivery(false);
            builder.SetPersonalPreferences("Есть дополнительные пожелания к заказу!");
        }

        public void CreateSpecialUrgentOrder(IOrderBuilder builder)  // метод для создания особенного срочного заказа
        {
            builder.CreateOrder();
            builder.SetFastDelivery(true);
            builder.SetPersonalPreferences("Есть дополнительные пожелания к заказу!");
        }

    }
}