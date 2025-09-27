namespace VendingMachine
{

    public class Machine
    {
        private Dictionary<ushort, ushort> _money;  // {denomination, count}
        private Dictionary<ushort, string> _products; // {product id, name}
        private Dictionary<ushort, List<ushort>> _products_info; // {product id, {price, ammount}}

        public Machine(Dictionary<ushort, ushort> money, Dictionary<ushort, string> products, Dictionary<ushort, List<ushort>> products_info)
        {
            _money = money;
            _products = products;
            _products_info = products_info;
        }

        public void PrintOptions()
        {
            Console.WriteLine("Выберите действие: \n\t 1. Приобрести товар \n\t 2. Добавить товар (+ денежные операции) \n");
            string option = Console.ReadLine();
            if (option == "1")
            {
                PrintProductsList();
            }
            else if (option == "2")
            {
                Console.Write("Введите логин: ");
                string login = Console.ReadLine();
                Console.Write("Введите пароль: ");
                string password = Console.ReadLine();
                Admin admin = new Admin(_money, _products, _products_info);
                admin.LogIn(login, password);
            }
            else
            {
                Console.WriteLine("Идите на ?sh kakhf? ai'd dur-rugnul");
            }

        }


        public void PrintProductsList()
        {
            Console.WriteLine("Список товаров в наличии:");
            foreach (var product in _products)
            {
                ushort price = _products_info[product.Key][0];
                ushort ammount = _products_info[product.Key][1];
                if (ammount != 0)
                {
                    Console.WriteLine($"\t{product.Key}.{product.Value}, цена: {price} руб., кол-во: {ammount}");


                }
            }
            Console.WriteLine("Выберите товар: ");
            ushort id = Convert.ToUInt16(Console.ReadLine());

            if ((_products.Keys.Contains(id)) && (_products_info[id][1] > 0))
            {
                AcceptMoney(id, _products_info[id][0]);
            }
            else {
                Console.WriteLine("Неверный идентификатор");
                PrintProductsList();
            }
        }

        public void AcceptMoney(ushort id, ushort ammount)
        {
            Console.WriteLine($"Внесите сумму {ammount}");
            ushort sum = 0;
            Dictionary<ushort, ushort> added_money = new Dictionary<ushort, ushort>(_money);
            foreach (ushort denomination in _money.Keys)
            {
                Console.Write($"Кол-во монет/купюр по {denomination} рублей: ");
                ushort count = Convert.ToUInt16(Console.ReadLine());
                added_money[denomination] += count;
                sum += Convert.ToUInt16(count * denomination);
                if (sum >= ammount)
                {
                    ushort change = Convert.ToUInt16(sum - ammount);
                    if (change > 0)
                    {
                        Console.WriteLine($"Средств достаточно, сдача {change} рублей. Возьмите товар и сдачу :)");
                        _money = added_money;
                        _products_info[id][1] -= 1;
                        GiveChange(change);
                    }
                    else
                    {
                        Console.WriteLine($"Средств достаточно. Возьмите товар :)");
                        _money = added_money;
                        _products_info[id][1] -= 1;
                        break;

                    }

                    
                }
            }
            if (sum < ammount)
            {
                Console.WriteLine($"Недостаточно {ammount - sum} руб.");
                foreach (ushort denomination in added_money.Keys)
                {
                    ushort count = Convert.ToUInt16(added_money[denomination] - _money[denomination]);
                    if (count > 0)
                    {
                        Console.WriteLine($"Возвращенные средства: {DeclineByCases(count, denomination)}");
                    }
                }


            }
            ContinueOperations();

        }
        public static string DeclineByCases(ushort count, ushort denomination)
        {
            string word = (denomination < 50) ? "монет" : "купюр";
            count %= 10;
            if (count == 1)
            {
                word += "а";
            }
            else if (count < 5)
            {
                word += "ы";
            }

            return $"{count} {word} по {denomination} рублей.";
        }

        public void ContinueOperations()
        {
            Console.WriteLine("Хотите продолжить? Д/н");
            if (Console.ReadLine().ToLower() == "д")
            {
                Machine machine = new Machine(_money, _products, _products_info);
                machine.PrintOptions();
            }
        }

        public void GiveChange(ushort change)
        {
            foreach (ushort denomination in _money.Keys.Reverse())
            {
                ushort count = 0;
                while ((change >= denomination) & (_money[denomination] > 0))
                {
                    count++;
                    _money[denomination] -= 1;
                    change -= denomination;
                    if (change < denomination)
                    {
                        Console.WriteLine($"{DeclineByCases(count, denomination)}");

                    }
                }
            }
            ContinueOperations();


        }
    }
}