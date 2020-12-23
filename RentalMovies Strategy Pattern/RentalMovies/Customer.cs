using System.Collections.Generic;

namespace RentalMovies
{
    public class Customer
    {
        private readonly List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string Statement()
        {
            double totalAmount = 0;
            var frequentRenterPoints = 0;

            var result = "Rental Record for " + Name + "\n";
            foreach (var rental in _rentals)
            {
                var amount = rental.ComputeAmount();
                var thisAmount = amount;
                frequentRenterPoints += rental.ComputeFrequentRenterPoints();
                //show figures for this rental
                result += $"\t{rental.Movie.Title}\t{thisAmount}\n";
                totalAmount += thisAmount;
            }
            //add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints +
                      " frequent renter points";
            return result;
        }
    }
}