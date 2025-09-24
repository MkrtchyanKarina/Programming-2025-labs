using System.ComponentModel;
using System.ComponentModel.Design;

Dictionary<ushort, ushort> money = new Dictionary<ushort, ushort>(){
    { 1, 10 },
    { 2, 10 },
    { 5, 10 },
    { 10, 10 },
    { 50, 10 },
    { 100, 5 },
    { 200, 5 },
    { 500, 5 },
    { 1000, 2 },
    { 2000, 2 },
    { 5000, 2 }};
Dictionary<ushort, string> products = new Dictionary<ushort, string>();
Dictionary<ushort, List<ushort>> products_info = new Dictionary<ushort, List<ushort>>();
products[1] = "Шоколад Белый";
products[2] = "Шоколад Горький";

products_info[1] = new List<ushort> { 100, 3 };
products_info[2] = new List<ushort> { 120, 4 };


Machine machine = new Machine(money, products, products_info);


machine.PrintOptions();



public class Admin
{
    private Dictionary<ushort, ushort> _money;  // номинал монеты/купюры и кол-во
    private Dictionary<ushort, string> _products; // product id and name
    private Dictionary<ushort, List<ushort>> _products_info; // product id and {price, ammount}

    public Admin(Dictionary<ushort, ushort> money, Dictionary<ushort, string> products, Dictionary<ushort, List<ushort>> products_info)
    {
        _money = money;
        _products = products;
        _products_info = products_info;
    }

    private static Dictionary<string, string> _admins = new Dictionary<string, string>(){{"admin", "qwerty"}};


    public void LogIn(string login, string password) {
        if ((_admins.ContainsKey(login)) & (_admins[login] == password))
        {
            Console.WriteLine("Вам разрешено: \n\t 1. Добавление, изменение и удаление продуктов \n\t 2. Снятие и внесение средств. Выберите категорию действий: ");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                ProductOperations();
            }
            else {
                MoneyOperations();
            }
        }
        else
        {
            Console.WriteLine("Неверный логин или пароль!");
        }
    }
    //public static void ContinueOperations()
    //{
    //    Console.WriteLine("Хотите продолжить? Д/н");
    //    if (Console.ReadLine().ToLower() == "д")
    //    {
    //        Console.WriteLine("Остаться в режиме администратора? Д/н");
    //        if (Console.ReadLine().ToLower() == "д") {
    //            ProductOperations();
    //        }
    //        else {
    //            Machine machine = new Machine(_money, _products, _products_info);
    //        }
    //    }
    //}

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

        Console.WriteLine("Выберите действие: \n\t 1. Добавить \n\t 2. Изменить \n\t 3.Удалить");
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
        else 
        {
            Console.WriteLine("Введите id товара: ");
            ushort id = Convert.ToUInt16(Console.ReadLine());
            if (answer == "2") {
                
                Console.WriteLine("1. Изменить цену \n 2. Изменить количество");
                string operation = Console.ReadLine();
                if (operation == "1") {
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
            else {
                _products.Remove(id);
                _products_info.Remove(id);
            }
           

        }
        //ContinueOperations();

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

        if (action == "1")
        {
            _money[denomination] += Convert.ToUInt16(count);
        }

        else {
            _money[denomination] -= Convert.ToUInt16(count);
        }
        
        //ContinueOperations();
    }
}



public class Machine
{
    private Dictionary<ushort, ushort> _money;  // номинал монеты/купюры и кол-во
    private Dictionary<ushort, string> _products; // product id and name
    private Dictionary<ushort, List<ushort>> _products_info; // product id and {price, ammount}

    public Machine(Dictionary<ushort, ushort> money, Dictionary<ushort, string> products, Dictionary<ushort, List<ushort>> products_info) 
    {
        _money = money;
        _products = products;
        _products_info = products_info;
    }

    public void PrintOptions() { 
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
        else {
            Console.WriteLine("Идите на îsh kakhfê ai'd dur-rugnul");
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
  
        if ((_products.Keys.Contains(id)) & (_products_info[id][1] > 0)){
            AcceptMoney(id, _products_info[id][0]);
        }
    }

    public void AcceptMoney(ushort id, ushort ammount) {
        Console.WriteLine($"Внесите сумму {ammount}");
        ushort sum = 0;
        Dictionary<ushort, ushort> added_money = new Dictionary<ushort, ushort>(_money);
        foreach (ushort denomination in _money.Keys) {
            Console.Write($"Кол-во монет/купюр по {denomination} рублей: ");
            ushort count = Convert.ToUInt16(Console.ReadLine());
            added_money[denomination] += count;
            sum += Convert.ToUInt16(count * denomination);
            if (sum >= ammount) {
                ushort change = Convert.ToUInt16(sum - ammount);
                if (change > 0)
                {
                    Console.WriteLine($"Средств достаточно, сдача {change} рублей.");
                    GiveChange(change);
                }
                else {
                    Console.WriteLine($"Средств достаточно.");
                }
                
                _money = added_money;
                _products_info[id][1] -= 1;
                break;
            }
        }
        if (sum < ammount) {
            Console.WriteLine($"Недостаточно {ammount - sum} руб.");
            foreach (ushort denomination in added_money.Keys) { 
                ushort count = Convert.ToUInt16(added_money[denomination] - _money[denomination]);
                if (count > 0) { 
                    Console.WriteLine($"Возвращенные средства: {DeclineByCases(count, denomination)}");
                }
            }
            //ContinueOperations();

        }
        
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

    //public static void ContinueOperations() {
    //    Console.WriteLine("Хотите продолжить? Д/н");
    //    if (Console.ReadLine().ToLower() == "д")
    //    {
    //        Console.WriteLine("Продолжение");
    //    }
    //}

    public void GiveChange(ushort change) {
        foreach (ushort denomination in _money.Keys.Reverse()) {
            ushort count = 0;
            while ((change >= denomination) & (_money[denomination] > 0))
            {
                count ++;
                _money[denomination] -= 1;
                change -= denomination;
                if (change < denomination) {
                    Console.WriteLine($"{DeclineByCases(count, denomination)}");         
                    
                }
            }
        }
        //ContinueOperations();


    }










}