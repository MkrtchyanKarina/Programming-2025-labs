namespace delivery
{
    public abstract class AbstractCuisineFactory
    {
        public abstract Dish CreateAppetizer();  // метод добавления закуски
        public abstract Dish CreateMainCourse();  // метод добавления основного блюда
        public abstract Dish CreateDessert();  // метод добавления десерта

    }
    // возвращаем классы-наследники (блюда из конкретной кухни/меню) от класса блюдо
    public class ItalianCuisineFactory : AbstractCuisineFactory
    {
        public override Dish CreateAppetizer()
        {
            return new ItalianAppetizer();
        }

        public override Dish CreateMainCourse()
        {
            return new ItalianMainCourse();
        }

        public override Dish CreateDessert()
        {
            return new ItalianDessert();
        }
    }

    public class ChineseCuisineFactory : AbstractCuisineFactory
    {
        public override Dish CreateAppetizer()
        {
            return new ChineseAppetizer();
        }

        public override Dish CreateMainCourse()
        {
            return new ChineseMainCourse();
        }

        public override Dish CreateDessert()
        {
            return new ChineseDessert();
        }
    }
}