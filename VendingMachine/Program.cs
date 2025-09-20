Dictionary<ushort, ushort> money = new Dictionary<ushort, ushort>(){
    { 1, 10 },
    { 2, 10 },
    { 5, 10 },
    { 10, 10 },
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
        Console.WriteLine("Выберите действие: \n\t 1. Приобрести товар \n\t 2. Добавить товар \n");
        if (Console.ReadLine() == "1") {
            PrintProductsList();
        }
        else
        {
            Console.WriteLine("Функциональность добавится позже :)");
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
                Console.WriteLine($"Средств достаточно, сдача {change} рублей.");
                _money = added_money;
                _products_info[id][1] -= 1;
                break;
            }
        }
        if (sum < ammount) {
            Console.WriteLine("Средств недостаточно.");
        }
        
    }



    

}