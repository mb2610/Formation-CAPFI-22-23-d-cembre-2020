namespace RentalMovies.StrategyMovie
{
    public class NewReleaseMovie : IPriceMovie
    {
        public double Price(int daysRented)
        {
            double amount = 0;
            amount += daysRented * 3;
            return amount;
        }
    }
}