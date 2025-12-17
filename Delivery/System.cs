namespace delivery
{
    class Menu
    {
        public void Add()
        {
            Console.WriteLine("Добавили блюдо в заказ");
        }
        public void Delete()
        {
            Console.WriteLine("Убрали блюдо из заказа");
        }
    }
    class Calculator
    {
        public void CalcResult()
        {
            Console.WriteLine("Стоимость всего заказа с учетом акций и скидок");
        }
    }
    class Conditions
    {
        public void Ordinary()
        {
            Console.WriteLine("Обычный заказ");
        }

        public void Urgent()
        {
            Console.WriteLine("Срочный заказ");
        }
        public void Personal()
        {
            Console.WriteLine("Особенный заказ");
        }
    }

    class OrderFacade
    {
        Menu menu;
        Calculator calculator;
        Conditions condition;
        public OrderFacade(Menu menu, Calculator calculator, Conditions condition)
        {
            this.menu = menu;
            this.calculator = calculator;
            this.condition = condition;
        }
        public void DoOrder()
        {
            menu.Add();
            condition.Urgent();
            calculator.CalcResult();

        }

    }

    class Custumer
    {
        public void CreateOrder(OrderFacade facade)
        {
            facade.DoOrder();
        }
    }
}