
using NFluent;
using NUnit.Framework;

namespace LeapYearTest
{
    public class LeapYearShould
    {
        [Test]
        public void Return_true_when_year_is_normal_leap_year()
        {
            Check.That(LeapYear.IsLeap(1996)).IsTrue();
        }

        [Test]
        public void Return_true_when_year_is_no_common_leap_year()
        {
            Check.That(LeapYear.IsLeap(2000)).IsTrue();
        }

        [Test]
        public void Return_false_when_year_is_common_year()
        {
            Check.That(LeapYear.IsLeap(2001)).IsFalse();
        }

        [Test]
        public void Return_false_when_year_atypical_common_year()
        {
            Check.That(LeapYear.IsLeap(1900)).IsFalse();
        }
    }
}
