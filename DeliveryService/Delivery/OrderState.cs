namespace delivery
{
    public interface IOrderState
    {
        void StartOrder(Order order);
        void FinishOrder(Order order);
        void PrintOrderState();
    }

    public class AcceptedOrderState : IOrderState  // принятый заказ
    {
        public void PrintOrderState()
        {
            Console.WriteLine("Заказ принят.");
        }

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

    public class InProgressOrderState : IOrderState  // заказ в процессе
    {
        public void PrintOrderState()
        {
            Console.WriteLine("Заказ в процессе.");
        }

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

    public class ReadyOrderState : IOrderState  // готовый заказ
    {
        public void PrintOrderState()
        {
            Console.WriteLine("Заказ готов.");
        }

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