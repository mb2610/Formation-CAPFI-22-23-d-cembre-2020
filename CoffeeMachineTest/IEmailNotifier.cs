namespace CoffeeMachineTest
{
    public interface IEmailNotifier
    {
        void NotifyMissingDrink(KindOfDrink drink);
    }
}