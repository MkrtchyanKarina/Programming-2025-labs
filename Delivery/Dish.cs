namespace delivery
{
    enum DishType
    { 
        Appetizer,
        MainCourse,
        Dessert,
    }

    internal class Dish
    {
        internal string Name { get; set; }
        internal DishType Type { get; set; }
        internal int Cost { get; set; }
        internal int Weight { get; set; }
        internal string Ingridients { get; set; } = "";

        internal Dish(string name, DishType type, int cost, int weight, string ingridients="") 
        { 
            Name = name;
            Type = type;
            Cost = cost;
            Weight = weight;
            Ingridients = ingridients;
        }

        internal void PrintInfo()
        {
            Console.WriteLine($"Блюдо: {Name} | Цена: {Cost} | Масса: {Weight} | Ингридиенты: {Ingridients}");
        }
    }


    internal class ItalianAppetizer : Dish
    {
        internal ItalianAppetizer() : base("Брускетта", DishType.Appetizer, 250, 150,
            "Хлеб, помидоры, базилик, чеснок") 
        { }
    }

    internal class ItalianMainCourse : Dish
    {
        internal ItalianMainCourse() : base("Паста Карбонара", DishType.MainCourse, 500, 350,
            "Спагетти, бекон, яйца, пармезан, перец") 
        { }
    }

    internal class ItalianDessert : Dish
    {
        internal ItalianDessert() : base("Тирамису", DishType.Dessert, 350, 200,
            "Печенье савоярди, маскарпоне, кофе, какао")
        { }
    }

    internal class ChineseAppetizer : Dish
    {
        internal ChineseAppetizer() : base("Вонтоны", DishType.Appetizer, 300, 200,
            "Тесто, свиной фарш, имбирь, соевый соус")
        { }
    }

    internal class ChineseMainCourse : Dish
    {
        internal ChineseMainCourse() : base("Утка по-пекински", DishType.MainCourse, 800, 400,
            "Утка, мед, соевый соус, имбирь, лепешки")
        { }
    }

    internal class ChineseDessert : Dish
    {
        internal ChineseDessert() : base("Фрукты в сиропе", DishType.Dessert, 200, 150,
            "Ананас, личи, имбирный сироп")
        { }
    } 

}