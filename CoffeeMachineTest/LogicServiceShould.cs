using NFluent;
using NSubstitute;
using NUnit.Framework;

namespace CoffeeMachineTest
{
    public class LogicServiceShould
    {
        private IBeverageQuantityChecker _beverageQuantityChecker;
        private BusinessReport _businessReport;
        private IEmailNotifier _emailNotifier;
        private LogicService _logicService;

        [SetUp]
        public void SetUp()
        {
            _beverageQuantityChecker = Substitute.For<IBeverageQuantityChecker>();
            _emailNotifier = Substitute.For<IEmailNotifier>();
            _businessReport = new BusinessReport();
            _logicService = new LogicService(_businessReport, _beverageQuantityChecker, _emailNotifier);
        }

        [Test]
        public void
            Produce_a_drink_maker_command_for_1_tea_with_1_sugar_and_a_tick_when_receive_the_order_for_this_drink()
        {
            Check.That(_logicService.ProvideCommandForDrinkMaker(new CustomerOrder(KindOfDrink.Tea, 0.4, 1))).IsEqualTo("T:1:0");
        }

        [Test]
        public void Produce_a_drink_maker_command_for_1_chocolate_with_no_sugar_when_receive_the_order_for_this_drink()
        {
            var customerOrder = new CustomerOrder(KindOfDrink.Chocolate, 0.5);
            Check.That(_logicService.ProvideCommandForDrinkMaker(customerOrder)).IsEqualTo("H::");
        }

        [Test]
        public void
            Produce_a_drink_maker_command_for_1_coffee_with_2_sugars_and_a_stick_when_receive_the_order_for_this_drink()
        {
            Check.That(_logicService.ProvideCommandForDrinkMaker(new CustomerOrder(KindOfDrink.Coffee, 0.6, 2))).IsEqualTo("C:2:0");
        }

        [Test]
        public void Send_message_how_money_missing_when_receive_an_order_with_not_enough_money()
        {
            Check.That(_logicService.ProvideCommandForDrinkMaker(new CustomerOrder(KindOfDrink.Coffee, 0.2, 2)))
                .IsEqualTo("M:Money missing: 0,4");
        }

        [Test]
        public void
            Produce_a_drink_maker_command_for_1_orange_juice_when_receive_the_order_for_this_drink()
        {
            Check.That(_logicService.ProvideCommandForDrinkMaker(new CustomerOrder(KindOfDrink.OrangeJuice, 0.6))).IsEqualTo("O::");
        }

        [Test]
        public void
            Produce_a_drink_maker_command_for_1_an_extra_hot_coffee_with_no_sugar_when_receive_the_order_for_this_drink()
        {
            Check.That(_logicService.ProvideCommandForDrinkMaker(new CustomerOrder(KindOfDrink.Coffee, 0.6, 0, true)))
                .IsEqualTo("Ch::");
        }

        [Test]
        public void
            Produce_a_drink_maker_command_for_an_extra_hot_chocolate_with_one_sugar_and_a_stick_when_receive_the_order_for_this_drink()
        {
            Check.That(_logicService.ProvideCommandForDrinkMaker(new CustomerOrder(KindOfDrink.Chocolate, 0.6, 1, true)))
                .IsEqualTo("Hh:1:0");
        }

        [Test]
        public void
            Produce_a_drink_maker_command_for_an_extra_hot_tea_with_two_sugar_and_a_stick_when_receive_the_order_for_this_drink()
        {
            Check.That(_logicService.ProvideCommandForDrinkMaker(new CustomerOrder(KindOfDrink.Tea, 0.6, 2, true)))
                .IsEqualTo("Th:2:0");
        }

        [Test]
        public void Report_how_many_of_each_drink_was_sold_and_the_total_amount_of_money_earned()
        {
            _logicService.ProvideCommandForDrinkMaker(new CustomerOrder(KindOfDrink.Tea, 0.6, 2, true));
            _logicService.ProvideCommandForDrinkMaker(new CustomerOrder(KindOfDrink.Tea, 0.6, 2, true));
            _logicService.ProvideCommandForDrinkMaker(new CustomerOrder(KindOfDrink.Chocolate, 0.6));
            _logicService.ProvideCommandForDrinkMaker(new CustomerOrder(KindOfDrink.OrangeJuice, 0.6));
            _logicService.ProvideCommandForDrinkMaker(new CustomerOrder(KindOfDrink.OrangeJuice, 0.6));
            _logicService.ProvideCommandForDrinkMaker(new CustomerOrder(KindOfDrink.OrangeJuice, 0.6));
            _logicService.ProvideCommandForDrinkMaker(new CustomerOrder(KindOfDrink.Coffee, 0.6));
            _logicService.ProvideCommandForDrinkMaker(new CustomerOrder(KindOfDrink.Coffee, 0.6));
            _logicService.ProvideCommandForDrinkMaker(new CustomerOrder(KindOfDrink.Coffee, 0.6));
            _logicService.ProvideCommandForDrinkMaker(new CustomerOrder(KindOfDrink.Coffee, 0.6));

            Check.That(_businessReport.TotalBeverageSold()).IsEqualTo(10);
            Check.That(_businessReport.BeverageCount(KindOfDrink.Tea)).IsEqualTo(2);
            Check.That(_businessReport.BeverageCount(KindOfDrink.Chocolate)).IsEqualTo(1);
            Check.That(_businessReport.BeverageCount(KindOfDrink.OrangeJuice)).IsEqualTo(3);
            Check.That(_businessReport.BeverageCount(KindOfDrink.Coffee)).IsEqualTo(4);

            Check.That(_businessReport.TotalAmount).IsEqualTo(5.5);
        }

        [Test]
        public void Notify_by_email_when_a_beverage_is_missing()
        {
            // we defined the stub behavior
            _beverageQuantityChecker.IsEmpty(KindOfDrink.Chocolate).Returns(true);

            _logicService.ProvideCommandForDrinkMaker(new CustomerOrder(KindOfDrink.Chocolate, 0.5));
            
            // we assert the mock to validate the stub behavior
            _emailNotifier.Received().NotifyMissingDrink(KindOfDrink.Chocolate);
        }
    }
}