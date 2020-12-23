namespace RentalMovies
{
    public class Rental
    {
        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public int DaysRented { get; }

        public Movie Movie { get; }

        public double ComputeAmount()
        {
            return Movie.Price(DaysRented);
        }

        public int ComputeFrequentRenterPoints()
        {
            // add bonus for a two day new release rental
            return Movie.IsNewRelease() && DaysRented > 1 ? 2 : 1;
        }
    }
}