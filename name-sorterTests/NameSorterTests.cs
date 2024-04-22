using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter.Tests
{
    [TestFixture]
    public class NameSorterTests
    {
        [Test]
        public void Test_SortNames_NullInput_ThrowsException()
        {
            // Arrange
            List<Name> names = null;

            // Act & Assert
            // Verify that sorting null input throws an ArgumentNullException
            Assert.Throws<ArgumentNullException>(() => NameSorter.SortNames(names));
        }

        [Test]
        public void Test_SortNames_EmptyList_NoError()
        {
            // Arrange
            List<Name> names = new List<Name>();

            // Act & Assert
            // Verify that sorting an empty list does not throw any error
            Assert.DoesNotThrow(() => NameSorter.SortNames(names));
        }

        [Test]
        public void Test_Sorting_By_LastName()
        {
            // Arrange
            List<Name> names = new List<Name>
            {
                new Name("Smith", new string[] { "John" }),
                new Name("Doe", new string[] { "Jane" }),
                new Name("Johnson", new string[] { "Alice" })
            };

            // Act
            NameSorter.SortNames(names);

            // Assert
            // Verify that names are sorted by last name in ascending order
            Assert.That(names[0].LastName, Is.EqualTo("Doe"));
            Assert.That(names[1].LastName, Is.EqualTo("Johnson"));
            Assert.That(names[2].LastName, Is.EqualTo("Smith"));
        }

        [Test]
        public void Test_Sorting_By_GivenNames()
        {
            // Arrange
            List<Name> names = new List<Name>
            {
                new Name("Doe", new string[] { "Jane" }),
                new Name("Doe", new string[] { "Alice" }),
                new Name("Doe", new string[] { "John" })
            };

            // Act
            NameSorter.SortNames(names);

            // Assert
            // Verify that names are sorted by given names in ascending order
            Assert.That(names[0].GivenNames[0], Is.EqualTo("Alice"));
            Assert.That(names[1].GivenNames[0], Is.EqualTo("Jane"));
            Assert.That(names[2].GivenNames[0], Is.EqualTo("John"));
        }

        [Test]
        public void Test_Sorting_With_Multiple_Given_Names()
        {
            // Arrange
            List<Name> names = new List<Name>
            {
                new Name("Doe", new string[] { "Alice", "Beth" }),
                new Name("Doe", new string[] { "Alice", "Bob" }),
                new Name("Doe", new string[] { "Alice" })
            };

            // Act
            NameSorter.SortNames(names);

            // Assert
            // Verify that names with multiple given names come before names with fewer given names
            Assert.That(names[0].GivenNames.Length, Is.EqualTo(1));
            Assert.That(names[1].GivenNames.Length, Is.EqualTo(2));
            Assert.That(names[2].GivenNames.Length, Is.EqualTo(2));
        }

        [Test]
        public void Test_Sorting_With_Different_Lengths_Of_Given_Names()
        {
            // Arrange
            List<Name> names = new List<Name>
            {
                new Name("Doe", new string[] { "Alice" }),
                new Name("Doe", new string[] { "Alice", "Beth" }),
                new Name("Doe", new string[] { "Alice", "Beth", "Charlie" })
            };

            // Act
            NameSorter.SortNames(names);

            // Assert
            // Verify that names with different lengths of given names are sorted correctly
            Assert.That(names[0].GivenNames.Length, Is.EqualTo(1));
            Assert.That(names[1].GivenNames.Length, Is.EqualTo(2));
            Assert.That(names[2].GivenNames.Length, Is.EqualTo(3));
        }

        [Test]
        public void Test_Sorting_With_Different_Cases()
        {
            // Arrange
            List<Name> names = new List<Name>
            {
                new Name("Doe", new string[] { "Alice" }),
                new Name("doe", new string[] { "Bob" }),
                new Name("DOE", new string[] { "Charlie" })
            };

            // Act
            NameSorter.SortNames(names);

            // Assert
            // Verify that names with different cases are sorted correctly
            Assert.That(names[0].GivenNames[0], Is.EqualTo("Alice"));
            Assert.That(names[1].GivenNames[0], Is.EqualTo("Bob"));
            Assert.That(names[2].GivenNames[0], Is.EqualTo("Charlie"));
        }

        [Test]
        public void Test_Sorting_With_Names_In_Various_Orders()
        {
            // Arrange
            List<Name> names = new List<Name>
            {
                new Name("Doe", new string[] { "Alice" }),
                new Name("Smith", new string[] { "Bob" }),
                new Name("Johnson", new string[] { "Charlie" })
            };

            // Randomize the order of names
            Random rng = new Random();
            names = names.OrderBy(name => rng.Next()).ToList();

            // Act
            NameSorter.SortNames(names);

            // Assert
            // Verify that sorting produces the same result regardless of the order of names
            Assert.That(names[0].LastName, Is.EqualTo("Doe"));
            Assert.That(names[1].LastName, Is.EqualTo("Johnson"));
            Assert.That(names[2].LastName, Is.EqualTo("Smith"));
        }

        [Test]
        public void Test_Sorting_With_Duplicates()
        {
            // Arrange
            List<Name> names = new List<Name>
            {
                new Name("Doe", new string[] { "Charlie" }),
                new Name("Doe", new string[] { "Alice" }),
                new Name("Doe", new string[] { "Bob" }),
                new Name("Smith", new string[] { "David" }),
                new Name("Smith", new string[] { "Eva" }),
                new Name("Smith", new string[] { "Alice" })
            };

            // Act
            NameSorter.SortNames(names);

            // Assert
            // Verify that duplicate names are handled correctly
            Assert.That(names[0].GivenNames[0], Is.EqualTo("Alice"));
            Assert.That(names[1].GivenNames[0], Is.EqualTo("Bob"));
            Assert.That(names[2].GivenNames[0], Is.EqualTo("Charlie"));
            Assert.That(names[3].GivenNames[0], Is.EqualTo("Alice"));
            Assert.That(names[4].GivenNames[0], Is.EqualTo("David"));
            Assert.That(names[5].GivenNames[0], Is.EqualTo("Eva"));
        }

    }
}
