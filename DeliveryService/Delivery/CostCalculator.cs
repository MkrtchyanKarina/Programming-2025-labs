namespace delivery
{
    // Интерфейс стратегии расчета
    public interface IPricingStrategy
    {
        decimal CalculatePrice(Order order);
        string GetDescription();
    }

    // Конкретные стратегии

    public class StandardPricing : IPricingStrategy // расчет для обычного заказа
    {
        public decimal CalculatePrice(Order order)
        {
            decimal baseCost = order.GetBaseCost();  // получаем стоимость блюд
            decimal tax = baseCost * 0.13m;  // считаем налог
            decimal delivery = baseCost < 1000 ? 300 : 200;  // считаем стоимоть доставки в зависимости от стоимости заказа
            return baseCost + tax + delivery;  // финальный результат
        }
        public string GetDescription()
        {
            return "Стандартный расчет (налог 13% + доставка)";
        }
    }


    public class DiscountPricing : IPricingStrategy  // расчет для заказа со скидкой
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

        public string GetDescription()
        {
            return $"Расчет со скидкой {_discountPercent}%";
        }
    }


    public class UrgentPricing : IPricingStrategy  // расчет для срочного заказа (выше стоимоть доставки)
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


    public class CombinedPricing : IPricingStrategy  // срочность и скидка
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

            // применяем скидку
            decimal afterDiscount = baseCost;
            if (_discountPercent > 0)
            {
                afterDiscount = baseCost * (1 - (_discountPercent / 100));
            }

            decimal withTax = afterDiscount * 1.13m;  // стоимость с налогом            
            decimal delivery = _isUrgent ? 500 : (withTax < 1000 ? 300 : 200);  // считаем стоимость доставки

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