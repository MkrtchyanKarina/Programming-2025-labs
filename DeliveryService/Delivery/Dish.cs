namespace delivery
{
    public enum DishType
    { 
        Appetizer,
        MainCourse,
        Dessert,
    }

    public class Dish
    {
        public string Name { get; set; }
        public DishType Type { get; set; }
        public int Cost { get; set; }
        public int Weight { get; set; }
        public string Ingridients { get; set; } = "";

        public Dish(string name, DishType type, int cost, int weight, string ingridients="") 
        { 
            Name = name;
            Type = type;
            Cost = cost;
            Weight = weight;
            Ingridients = ingridients;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Блюдо: {Name} | Цена: {Cost} | Масса: {Weight} | Ингридиенты: {Ingridients}");
        }
    }


    public class ItalianAppetizer : Dish
    {
        public ItalianAppetizer() : base("Брускетта", DishType.Appetizer, 250, 150,
            "Хлеб, помидоры, базилик, чеснок") 
        { }
    }

    public class ItalianMainCourse : Dish
    {
        public ItalianMainCourse() : base("Паста Карбонара", DishType.MainCourse, 500, 350,
            "Спагетти, бекон, яйца, пармезан, перец") 
        { }
    }

    public class ItalianDessert : Dish
    {
        public ItalianDessert() : base("Тирамису", DishType.Dessert, 350, 200,
            "Печенье савоярди, маскарпоне, кофе, какао")
        { }
    }

    public class ChineseAppetizer : Dish
    {
        public ChineseAppetizer() : base("Вонтоны", DishType.Appetizer, 300, 200,
            "Тесто, свиной фарш, имбирь, соевый соус")
        { }
    }

    public class ChineseMainCourse : Dish
    {
        public ChineseMainCourse() : base("Утка по-пекински", DishType.MainCourse, 800, 400,
            "Утка, мед, соевый соус, имбирь, лепешки")
        { }
    }

    public class ChineseDessert : Dish
    {
        public ChineseDessert() : base("Фрукты в сиропе", DishType.Dessert, 200, 150,
            "Ананас, личи, имбирный сироп")
        { }
    } 

}