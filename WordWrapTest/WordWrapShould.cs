using NFluent;
using NUnit.Framework;

namespace WordWrapTest
{
    public class WordWrapShould
    {
        [Test]
        public void Wrap_without_break()
        {
            Check.That(Wrapper.Wrap("12345", 10)).Equals("12345");
        }

        [Test]
        public void Wrap_and_breaks_once()
        {
            Check.That(Wrapper.Wrap("12", 1)).Equals("1\n2");
        }

        [Test]
        public void Wrap_and_break_twice()
        {
            Check.That(Wrapper.Wrap("123", 1)).IsEqualTo("1\n2\n3");
        }

        [Test]
        public void Wrap_and_break_four_time()
        {
            Check.That(Wrapper.Wrap("12345678910111213", 4)).Equals("1234\n5678\n9101\n1121\n3");
        }

        [Test]
        public void Wrap_and_break_once_with_one_space_in_text()
        {
            Check.That(Wrapper.Wrap("1234 5", 4)).Equals("1234\n5");
        }

        [Test]
        public void Wrap_and_break_trice_with_tree_spaces_in_text()
        {
            Check.That(Wrapper.Wrap("12 345 678", 4)).Equals("12\n345\n678");
        }

        [TestCase("Clean Code. A Handbook of Agile Software Craftsmanship",
            "Clean Code. A\nHandbook of Agile\nSoftware\nCraftsmanship", 20)]
        [TestCase("Growing Object-Oriented Software Guided By Tests",
            "Growing\nObject-Oriented\nSoftware Guided\nBy Tests", 15)]
        public void Should_break_a_real_phrase(string text, string expected, int columnNumber)
        {
            Check.That(Wrapper.Wrap(text, columnNumber)).Equals(expected);
        }
    }
}