using System;
using System.Collections.Generic;

namespace CoffeeMachineTest
{
    public class LogicService
    {
        private readonly IBeverageQuantityChecker _beverageQuantityChecker;
        private readonly BusinessReport _businessReport;
        private readonly IEmailNotifier _emailNotifier;

        private Dictionary<KindOfDrink, (string drinkCommand, double drinkPrice)> DrinksToCommands { get; } =
            new Dictionary<KindOfDrink, (string drinkCommand, double drinkPrice)>
            {
                [KindOfDrink.Tea] = ("T", 0.4),
                [KindOfDrink.Coffee] = ("C", 0.6),
                [KindOfDrink.Chocolate] = ("H", 0.5),
                [KindOfDrink.OrangeJuice] = ("O", 0.6)
            };

        public LogicService(BusinessReport businessReport, IBeverageQuantityChecker beverageQuantityChecker,
            IEmailNotifier emailNotifier)
        {
            _businessReport = businessReport;
            _beverageQuantityChecker = beverageQuantityChecker;
            _emailNotifier = emailNotifier;
        }

        public string ProvideCommandForDrinkMaker(CustomerOrder customerOrder)
        {
            if (_beverageQuantityChecker.IsEmpty(customerOrder.KindOfDrink))
            {
                _emailNotifier.NotifyMissingDrink(customerOrder.KindOfDrink);
                return MessageFailureMissingDrink(customerOrder);
            }

            var (drinkPrice, drinkCommand) = ExtractCommandAndPrice(customerOrder);

            if (NotEnoughMoneyToPayDrink(drinkPrice, customerOrder))
                return MessageFailureMoneyMissing(customerOrder, drinkPrice);

            var drinkMakerCommand = DrinkMakerCommand(customerOrder, drinkCommand);

            _businessReport.AddBeverageSold(DrinksToCommands, customerOrder);
            
            return drinkMakerCommand;
        }

        private static string MessageFailureMissingDrink(CustomerOrder customerOrder)
        {
            return $"M:Missing drink: {customerOrder.KindOfDrink}";
        }

        private static string DrinkMakerCommand(CustomerOrder customerOrder, string drinkCommand)
        {
            var (withSugar, withStick) = BuildSugarCommand(customerOrder);
            return $"{drinkCommand}:{withSugar}:{withStick}";
        }

        private static string MessageFailureMoneyMissing(CustomerOrder customerOrder, double drinkPrice)
        {
            return $"M:Money missing: {Math.Round(drinkPrice - customerOrder.CustomerMoney, 2)}";
        }

        private static bool NotEnoughMoneyToPayDrink(double drinkPrice, CustomerOrder customerOrder)
        {
            return drinkPrice > customerOrder.CustomerMoney;
        }

        private (double drinkPrice, string drinkCommand) ExtractCommandAndPrice(CustomerOrder customerOrder)
        {
            var (drinkCommand, drinkPrice) = DrinksToCommands[customerOrder.KindOfDrink];

            if (customerOrder.ExtraHot) drinkCommand += "h";

            return (drinkPrice, drinkCommand);
        }

        private static (string sugarNumber, string stick) BuildSugarCommand(CustomerOrder customerOrder)
        {
            if (customerOrder.WithSugar == 0) return (string.Empty, string.Empty);

            return (customerOrder.WithSugar > 0 ? $"{customerOrder.WithSugar}" : "0",
                customerOrder.WithSugar > 0 ? "0" : "1");
        }
    }
}