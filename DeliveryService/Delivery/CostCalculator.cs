namespace delivery
{
    // Интерфейс стратегии расчета
    public interface IPricingStrategy
    {
        decimal CalculatePrice(Order order);
        string GetDescription();
    }

    // Конкретные стратегии
    public class StandardPricing : IPricingStrategy
    {
        public decimal CalculatePrice(Order order)
        {
            decimal baseCost = order.GetBaseCost();
            decimal tax = baseCost * 0.13m;
            decimal delivery = baseCost < 1000 ? 300 : 200;
            return baseCost + tax + delivery;
        }

        public string GetDescription() => "Стандартный расчет (налог 13% + доставка)";
    }

    public class DiscountPricing : IPricingStrategy
    {
        private readonly decimal _discountPercent;

        public DiscountPricing(decimal discountPercent = 10)
        {
            _discountPercent = discountPercent;
        }

        public decimal CalculatePrice(Order order)
        {
            decimal baseCost = order.GetBaseCost();
            decimal discount = baseCost * (_discountPercent / 100);
            decimal afterDiscount = baseCost - discount;
            decimal tax = afterDiscount * 0.13m;
            decimal delivery = afterDiscount < 1000 ? 300 : 200;
            return afterDiscount + tax + delivery;
        }

        public string GetDescription() => $"Расчет со скидкой {_discountPercent}%";
    }

    public class UrgentPricing : IPricingStrategy
    {
        public decimal CalculatePrice(Order order)
        {
            decimal baseCost = order.GetBaseCost();
            decimal tax = baseCost * 0.13m;
            decimal delivery = 500; // Фиксированная срочная доставка
            return baseCost + tax + delivery;
        }

        public string GetDescription() => "Срочный заказ (доставка 500 руб.)";
    }

    public class CombinedPricing : IPricingStrategy
    {
        private readonly bool _isUrgent;
        private readonly decimal _discountPercent;

        public CombinedPricing(bool isUrgent = false, decimal discountPercent = 0)
        {
            _isUrgent = isUrgent;
            _discountPercent = discountPercent;
        }

        public decimal CalculatePrice(Order order)
        {
            decimal baseCost = order.GetBaseCost();

            // Применяем скидку
            decimal afterDiscount = baseCost;
            if (_discountPercent > 0)
            {
                afterDiscount = baseCost * (1 - (_discountPercent / 100));
            }

            // Применяем налог
            decimal withTax = afterDiscount * 1.13m;

            // Применяем доставку
            decimal delivery = _isUrgent ? 500 : (withTax < 1000 ? 300 : 200);

            return withTax + delivery;
        }

        public string GetDescription()
        {
            string desc = "Расчет: ";
            if (_discountPercent > 0) desc += $"скидка {_discountPercent}%, ";
            desc += "налог 13%, ";
            desc += _isUrgent ? "срочная доставка 500 руб." : "стандартная доставка";
            return desc;
        }
    }


}