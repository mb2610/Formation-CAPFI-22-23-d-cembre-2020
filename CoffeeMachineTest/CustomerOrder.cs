namespace CoffeeMachineTest
{
    public class CustomerOrder
    {
        public double CustomerMoney { get; }
        public KindOfDrink KindOfDrink { get; }
        public int WithSugar { get; }
        public bool ExtraHot { get; }

        public CustomerOrder(KindOfDrink kindOfDrink, double customerMoney, int withSugar = 0, bool extraHot = false)
        {
            KindOfDrink = kindOfDrink;
            CustomerMoney = customerMoney;
            WithSugar = withSugar;
            ExtraHot = extraHot;
        }
    }
}