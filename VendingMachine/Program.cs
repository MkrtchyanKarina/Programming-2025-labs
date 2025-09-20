Machine.PrintProductsList();
public static class Machine
{


    public static void PrintProductsList()
    {
        Dictionary<ushort, ushort> money = new Dictionary<ushort, ushort>();  // номинал монеты/купюры и кол-во
        Dictionary<string, List<ushort>> products = new Dictionary<string, List<ushort>>(); // название продукта, [цена, кол-во]

        products["Шоколад Белый"] = new List<ushort>() { 90, 0 };
        products["Шоколад Горький"] = new List<ushort>() { 110, 4 };

        Console.WriteLine("Список товаров в наличии:");
        foreach (var product in products)
        {
            if (product.Value[1] != 0)
            {
                Console.WriteLine($"\t{product.Key}, цена: {product.Value[0]} руб.");

            }
        }
    }

}