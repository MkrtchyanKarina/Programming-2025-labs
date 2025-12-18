using delivery;
namespace TestDelivery
{
    public class IntegrationTests
    {
        // “ест 1: ѕолный цикл создани€ и расчета заказа
        [Fact]
        public void CompleteOrder_CreationAndPricing_WorksCorrectly()
        {
            // Arrange
            var facade = new DeliverySystemFacade();

            // Act
            // —оздаем италь€нский заказ (обычный)
            Order order = facade.CreateOrder(
                cuisineType: "италь€нска€",
                urgency: false,
                personalPreferences: "",
                addAppetizer: true,
                addMainCourse: true,
                addDessert: true
            );

            // ƒобавл€ем дополнительное блюдо
            order.SelectMainCourse(); // +1 паста

            // –асчет стоимости (стандартный)
            facade.ShowOrderWithCalculation(order);
            decimal standardTotal = order.CalculateTotalPrice();

            // –асчет со скидкой
            facade.ShowOrderWithCalculation(order, 15);
            decimal discountedTotal = order.CalculateTotalPrice();

            // ѕровер€ем состо€ние
            order.PrintOrderState();
            order.StartDoingOrder();
            order.FinishDoingOrder();

            // Assert
            // ѕровер€ем состав заказа
            Assert.True(order.GetBaseCost() > 0);

            // —тоимость со скидкой должна быть меньше стандартной
            Assert.True(discountedTotal < standardTotal);

            // ѕровер€ем, что все блюда добавлены
            Assert.True(order.GetBaseCost() >= (250 + 500 + 350)); // мин. стоимость 1 каждого блюда
        }

        // “ест 2: —оздание разных типов заказов через Director
        [Fact]
        public void OrderBuilder_CreatesDifferentOrderTypes_Correctly()
        {
            // Arrange
            var factory = new ItalianCuisineFactory();
            var builder = new OrderBuilder(factory);
            var director = new Director();

            // Act & Assert дл€ обычного заказа
            director.CreateRegularOrder(builder);
            var regularOrder = builder.GetOrder();
            Assert.False(regularOrder.Urgency);
            Assert.Equal("", regularOrder.PersonalPreferences);

            // Act & Assert дл€ срочного заказа
            director.CreateUrgentOrder(builder);
            var urgentOrder = builder.GetOrder();
            Assert.True(urgentOrder.Urgency);
            Assert.Equal("", urgentOrder.PersonalPreferences);

            // Act & Assert дл€ особенного заказа
            director.CreateSpecialOrder(builder);
            var specialOrder = builder.GetOrder();
            Assert.False(specialOrder.Urgency);
            Assert.Equal("≈сть дополнительные пожелани€ к заказу!", specialOrder.PersonalPreferences);

            // Act & Assert дл€ срочного особенного заказа
            director.CreateSpecialUrgentOrder(builder);
            var specialUrgentOrder = builder.GetOrder();
            Assert.True(specialUrgentOrder.Urgency);
            Assert.Equal("≈сть дополнительные пожелани€ к заказу!", specialUrgentOrder.PersonalPreferences);
        }

        // “ест 3: –асчет стоимости с разными стратеги€ми
        [Fact]
        public void PricingStrategies_CalculateCorrectly_ForDifferentScenarios()
        {
            // Arrange
            var factory = new ItalianCuisineFactory();
            var order = new Order(factory);

            // ƒобавл€ем блюда на сумму 1100 (500 + 250 + 350)
            order.SelectMainCourse();    // 500
            order.SelectAppetizer();     // 250
            order.SelectDessert();       // 350
            decimal baseCost = order.GetBaseCost(); // 1100

            // Act - стандартный расчет
            order.SetPricingStrategy(new StandardPricing());
            decimal standardTotal = order.CalculateTotalPrice();

            // Act - расчет со скидкой 10%
            order.SetPricingStrategy(new DiscountPricing(10));
            decimal discountedTotal = order.CalculateTotalPrice();

            // Act - срочный заказ
            order.Urgency = true;
            order.SetPricingStrategy(new UrgentPricing());
            decimal urgentTotal = order.CalculateTotalPrice();

            // Assert

            // —о скидкой: (1100 - 10%) + 13% налог + 300 доставка (т.к. 990 < 1000)
            decimal discountedBase = baseCost * 0.9m; // 990
            decimal expectedDiscounted = discountedBase * 1.13m + 300; // 990*1.13 + 300
            Assert.Equal(expectedDiscounted, discountedTotal, 2);
        }

        // “ест 4: ∆изненный цикл заказа и смена состо€ни€
        [Fact]
        public void OrderState_ChangesCorrectly_ThroughLifecycle()
        {
            // Arrange
            var factory = new ItalianCuisineFactory();
            var order = new Order(factory);

            // »значальное состо€ние
            Assert.IsType<AcceptedOrderState>(order.State);

            // Act 1 - начинаем готовить
            order.StartDoingOrder();

            // Assert 1 - перешли в состо€ние "в процессе"
            Assert.IsType<InProgressOrderState>(order.State);

            // Act 2 - завершаем заказ
            order.FinishDoingOrder();

            // Assert 2 - перешли в состо€ние "готов"
            Assert.IsType<ReadyOrderState>(order.State);

            // Act 3 - пытаемс€ снова начать (должно остатьс€ в состо€нии "готов")
            order.StartDoingOrder();

            // Assert 3 - осталось в состо€нии "готов"
            Assert.IsType<ReadyOrderState>(order.State);
        }
    }
}