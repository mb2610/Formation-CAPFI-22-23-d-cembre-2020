using System.Collections.Generic;

namespace RentalMovies.StrategyMovie
{
    public class StrategyFactoryMovie
    {
        private readonly Dictionary<Movie.KindOfMovie, IPriceMovie> _strategies = new Dictionary<Movie.KindOfMovie, IPriceMovie>
        {
            [Movie.KindOfMovie.Children] = new ChildrenMovie(),
            [Movie.KindOfMovie.NewRelease] = new NewReleaseMovie(),
            [Movie.KindOfMovie.Regular] = new RegularMovie()
        };

        public IPriceMovie GetMovie(Movie.KindOfMovie priceCode)
        {
            return _strategies[priceCode];
        }
    }
}