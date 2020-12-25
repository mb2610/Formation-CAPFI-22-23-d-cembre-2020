using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMachineTest
{
    public class BusinessReport
    {
        private double _totalAmount;
        private Dictionary<KindOfDrink, int> KindOfDrinks { get; } = new Dictionary<KindOfDrink, int>();

        public double TotalAmount => Math.Round(_totalAmount, 2);

        public int BeverageCount(KindOfDrink kindOfDrink)
        {
            return KindOfDrinks[kindOfDrink];
        }

        public int TotalBeverageSold()
        {
            return KindOfDrinks.Sum(kv => kv.Value);
        }

        public void AddBeverageSold(Dictionary<KindOfDrink, (string drinkCommand, double drinkPrice)> drinksToCommands,
            CustomerOrder customerOrder)
        {
            if (!KindOfDrinks.ContainsKey(customerOrder.KindOfDrink))
                KindOfDrinks[customerOrder.KindOfDrink] = 1;
            else
                KindOfDrinks[customerOrder.KindOfDrink]++;

            _totalAmount += drinksToCommands[customerOrder.KindOfDrink].drinkPrice;
        }
    }
}