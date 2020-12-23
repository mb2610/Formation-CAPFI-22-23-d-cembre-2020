using RentalMovies.StrategyMovie;

namespace RentalMovies
{
    public class Movie
    {
        private readonly StrategyFactoryMovie _strategyFactoryMovie;

        public enum KindOfMovie
        {
            Regular = 0,
            NewRelease = 1,
            Children = 2
        }

        private KindOfMovie PriceCode { get; }

        public string Title { get; }

        public Movie(string title, KindOfMovie priceCode)
        {
            Title = title;
            PriceCode = priceCode;
            _strategyFactoryMovie = new StrategyFactoryMovie();
        }

        public double Price(int daysRented)
        {
            return _strategyFactoryMovie.GetMovie(PriceCode).Price(daysRented);
        }

        public bool IsNewRelease()
        {
            return PriceCode == KindOfMovie.NewRelease;
        }
    }
}