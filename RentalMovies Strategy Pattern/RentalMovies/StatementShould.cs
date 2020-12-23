using NFluent;
using NUnit.Framework;

namespace RentalMovies
{
    public class StatementShould
    {
        [Test]
        public void Return_rental_record_when_rent_one_NEW_RELEASE_movie()
        {
            var customer = new Customer("Thomas");
            customer.AddRental(new Rental(new Movie("No Time to Die", Movie.KindOfMovie.NewRelease), 3));

            Check.That(
                    $"Rental Record for Thomas\n\tNo Time to Die\t{3 * 3}\nAmount owed is {3 * 3}\nYou earned {2} frequent renter points")
                .IsEqualTo(customer.Statement());
        }

        [Test]
        public void Return_rental_record_when_rent_one_REGULAR_movie()
        {
            var customer = new Customer("Bruno");
            customer.AddRental(new Rental(new Movie("Frozen II", Movie.KindOfMovie.Regular), 3));

            Check.That(
                    "Rental Record for Bruno\n\tFrozen II\t3,5\nAmount owed is 3,5\nYou earned 1 frequent renter points")
                .IsEqualTo(customer.Statement());
        }

        [Test]
        public void Return_rental_record_when_rent_one_CHILDREN_movie()
        {
            var customer = new Customer("Kenny");
            customer.AddRental(new Rental(new Movie("Star wars", Movie.KindOfMovie.Children), 4));

            Check.That("Rental Record for Kenny\n\tStar wars\t3\nAmount owed is 3\nYou earned 1 frequent renter points")
                .IsEqualTo(customer.Statement());
        }
    }
}