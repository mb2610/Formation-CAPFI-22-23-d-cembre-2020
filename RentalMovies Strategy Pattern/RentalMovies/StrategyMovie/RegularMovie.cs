namespace RentalMovies.StrategyMovie
{
    public class RegularMovie : IPriceMovie
    {
        public double Price(int daysRented)
        {
            double amount = 0;
            amount += 2;
            if (daysRented > 2)
                amount += (daysRented - 2) * 1.5;
            return amount;
        }
    }
}