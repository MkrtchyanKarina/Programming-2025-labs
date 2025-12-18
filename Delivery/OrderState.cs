namespace delivery
{
    internal interface IOrderState
    {
        void StartOrder(Order order);
        void FinishOrder(Order order);
    }

    class AcceptedOrderState : IOrderState
    {
        public void StartOrder(Order order)
        {
            Console.WriteLine("Приступили к Вашему заказу.");
            order.State = new InProgressOrderState();
        }

        public void FinishOrder(Order order)
        {
            Console.WriteLine("Продолжаем готовить Ваш заказ.");
        }
    }

    class InProgressOrderState : IOrderState
    {
        public void StartOrder(Order order)
        {
            Console.WriteLine("Продолжаем готовить Ваш заказ.");
        }

        public void FinishOrder(Order order)
        {
            Console.WriteLine("Ваш заказ готов!");
            order.State = new ReadyOrderState();
        }
    }

    class ReadyOrderState : IOrderState
    {
        public void StartOrder(Order order)
        {
            Console.WriteLine("Ваш заказ готов!");
        }

        public void FinishOrder(Order order)
        {
            Console.WriteLine("Ваш заказ готов! Спасибо за использование нашего сервиса!");
        }
    }
}