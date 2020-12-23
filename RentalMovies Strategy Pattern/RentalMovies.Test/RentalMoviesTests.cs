using System;
using NUnit.Framework;

namespace RentalMovies.Test
{
    [TestFixture]
    public class RentalMoviesTests
    {
        [Test]
        public void Should_return_rental_record_when_rent_one_NEW_RELEASE_movie()
        {
            const string user = "Sylvain";
            var customer = new Customer(user);
            const string movieTitle = "Espions";
            var movie = new Movie(movieTitle, Movie.NewRelease);
            var rental = new Rental(movie, 3);
            customer.AddRental(rental);
            var expected = String.Format("Rental Record for {0}\n\t{1}\t{2}\nAmount owed is {3}\nYou earned {4} frequent renter points", 
                user, movieTitle, 3 * 3, 3 * 3, 2);
            Assert.AreEqual(expected, customer.Statement());
        }

        [Test]
        public void Should_return_rental_record_when_rent_one_REGULAR_movie()
        {
            const string user = "Sylvain";
            var customer = new Customer(user);
            const string movieTitle = "Espions";
            var movie = new Movie(movieTitle, Movie.Regular);
            var rental = new Rental(movie, 3);
            customer.AddRental(rental);
            var expected = String.Format("Rental Record for {0}\n\t{1}\t3,5\nAmount owed is 3,5\nYou earned 1 frequent renter points",
                user, movieTitle);
            Assert.AreEqual(expected, customer.Statement());
        }

        [Test]
        public void Should_return_rental_record_when_rent_one_CHILDRENS_movie()
        {
            const string user = "Sylvain";
            var customer = new Customer(user);
            const string movieTitle = "Espions";
            var movie = new Movie(movieTitle, Movie.Children);
            var rental = new Rental(movie, 4);
            customer.AddRental(rental);
            var expected = String.Format("Rental Record for {0}\n\t{1}\t3\nAmount owed is 3\nYou earned 1 frequent renter points",
                user, movieTitle);
            Assert.AreEqual(expected, customer.Statement());
        }
    }
}
