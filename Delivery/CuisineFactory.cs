namespace delivery
{
    internal abstract class AbstractCuisineFactory
    {
        internal abstract Dish CreateAppetizer();
        internal abstract Dish CreateMainCourse();
        internal abstract Dish CreateDessert();

    }

    internal class ItalianCuisineFactory : AbstractCuisineFactory
    {
        internal override Dish CreateAppetizer()
        {
            return new ItalianAppetizer();
        }

        internal override Dish CreateMainCourse()
        {
            return new ItalianMainCourse();
        }

        internal override Dish CreateDessert()
        {
            return new ItalianDessert();
        }
    }

    internal class ChineseCuisineFactory : AbstractCuisineFactory
    {
        internal override Dish CreateAppetizer()
        {
            return new ChineseAppetizer();
        }

        internal override Dish CreateMainCourse()
        {
            return new ChineseMainCourse();
        }

        internal override Dish CreateDessert()
        {
            return new ChineseDessert();
        }
    }
}