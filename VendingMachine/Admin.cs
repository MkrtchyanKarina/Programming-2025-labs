namespace VendingMachine
{
    public class Admin
    {
        private Dictionary<ushort, ushort> _money;  // {denomination, count}
        private Dictionary<ushort, string> _products; // {product id, name}
        private Dictionary<ushort, List<ushort>> _products_info; // {product id, {price, ammount}}

        public Admin(Dictionary<ushort, ushort> money, Dictionary<ushort, string> products, Dictionary<ushort, List<ushort>> products_info)
        {
            _money = money;
            _products = products;
            _products_info = products_info;
        }

        private static Dictionary<string, string> _admins = new Dictionary<string, string>() { { "admin", "qwerty" } };



        public void LogIn(string login, string password)
        {
            if ((_admins.ContainsKey(login)) & (_admins[login] == password))

            {
                PrintOpntionsList();

            }
            else
            {
                Console.WriteLine("Неверный логин или пароль!");
                Machine machine = new Machine(_money, _products, _products_info);
                machine.PrintOptions();
            }
        }

        public void PrintOpntionsList()
        {
            Console.WriteLine("Вам разрешено: \n\t 1. Добавление, изменение и удаление продуктов \n\t 2. Снятие и внесение средств. Выберите категорию действий: ");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                ProductOperations();
            }
            else if (answer == "2")
            {
                MoneyOperations();
            }
            else
            {
                Console.WriteLine("Ответ неверный");
                PrintOpntionsList();
            }
        }

        public void ContinueOperations()
        {
            Console.WriteLine("Хотите продолжить? Д/н");
            if (Console.ReadLine().ToLower() == "д")
            {
                Console.WriteLine("Остаться в режиме администратора? Д/н");
                if (Console.ReadLine().ToLower() == "д")
                {
                    PrintOpntionsList();
                }
                else
                {
                    Machine machine = new Machine(_money, _products, _products_info);
                    machine.PrintOptions();
                }
            }
            
        }

        public void ProductOperations()
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

            Console.WriteLine("Выберите действие: \n\t 1. Добавить \n\t 2. Изменить \n\t 3. Удалить");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                Console.WriteLine("Введите наименование нового товара: ");
                string name = Console.ReadLine();
                Console.WriteLine("Введите его цену: ");
                ushort price = Convert.ToUInt16(Console.ReadLine());
                Console.WriteLine("Введите его количество: ");
                ushort count = Convert.ToUInt16(Console.ReadLine());

                ushort id = Convert.ToUInt16(1 + (_products.Count));
                _products.Add(id, name);
                _products_info.Add(id, [price, count]);
            }
            else if ((answer == "2") || answer == "3")
            {
                Console.WriteLine("Введите id товара: ");
                ushort id = Convert.ToUInt16(Console.ReadLine());
                if (answer == "2")
                {

                    Console.WriteLine("1. Изменить цену \n 2. Изменить количество");
                    string operation = Console.ReadLine();
                    if (operation == "1")
                    {
                        Console.WriteLine("Введите новую цену: ");
                        ushort price = Convert.ToUInt16(Console.ReadLine());
                        _products_info[id] = [price, _products_info[id][1]];
                    }
                    else
                    {
                        Console.WriteLine("Введите новое кол-во: ");
                        ushort count = Convert.ToUInt16(Console.ReadLine());
                        _products_info[id] = [_products_info[id][0], count];
                    }
                }
                else
                {
                    _products.Remove(id);
                    _products_info.Remove(id);
                }

            }
            else
            {
                Console.WriteLine("Выбрано неверное действие");
                ProductOperations();
            }
            ContinueOperations();

        }


        public void MoneyOperations()
        {
            Console.WriteLine("Деньги в кассе:");
            foreach (ushort d in _money.Keys)
            {

                Console.WriteLine($"\t {d} рублей: {_money[d]} штук.");

            }

            Console.WriteLine("Выберите действие: \n\t 1. Добавить \n\t 2. Снять");
            string action = Console.ReadLine();
            Console.WriteLine("Выберите номинал: ");
            ushort denomination = Convert.ToUInt16(Console.ReadLine());
            Console.WriteLine("Выберите количество: ");
            ushort count = Convert.ToUInt16(Console.ReadLine());

            if ((action == "1") && (_money[denomination] + count) <= 1000)
            {
                _money[denomination] += count;
            }

            else if ((action == "2") && (_money[denomination] - count) >= 0)
            {
                _money[denomination] -= count;
            }
            else {
                Console.WriteLine("Выбрано неверное дейсвтие или введена некорректная сумма");
                MoneyOperations();
            }


            ContinueOperations();
        }
    }

}