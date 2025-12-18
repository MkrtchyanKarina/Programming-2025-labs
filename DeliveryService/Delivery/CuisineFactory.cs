namespace delivery
{
    public abstract class AbstractCuisineFactory
    {
        public abstract Dish CreateAppetizer();
        public abstract Dish CreateMainCourse();
        public abstract Dish CreateDessert();

    }

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