namespace name_sorter.Tests
{
    [TestFixture]
    public class NameTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Constructor_NullLastName_ThrowsArgumentException()
        {
            // Act & Assert
            // Verify that passing a null last name to the constructor throws an ArgumentException
            Assert.Throws<ArgumentException>(() => new Name(null, new string[] { "John" }));
        }

        [Test]
        public void Constructor_NullGivenNames_ThrowsArgumentException()
        {
            // Act & Assert
            // Verify that passing null for given names to the constructor throws an ArgumentException
            Assert.Throws<ArgumentException>(() => new Name("Doe", null));
        }

        [Test]
        public void Constructor_EmptyGivenNames_ThrowsArgumentException()
        {
            // Act & Assert
            // Verify that passing an empty array for given names to the constructor throws an ArgumentException
            Assert.Throws<ArgumentException>(() => new Name("Doe", new string[0]));
        }

        [Test]
        public void CompareTo_NullOther_ThrowsArgumentNullException()
        {
            // Arrange
            Name name = new Name("Doe", new string[] { "John" });

            // Act & Assert
            // Verify that comparing to a null name throws an ArgumentNullException
            Assert.Throws<ArgumentNullException>(() => name.CompareTo(null));
        }

        [Test]
        public void Name_Representation_Correct()
        {
            // Arrange
            string expectedLastName = "Doe";
            string[] expectedGivenNames = { "John", "Robert" };
            string[] wrongOrderGivenName = { "Robert", "John" };
            // Act
            Name name = new Name(expectedLastName, expectedGivenNames);

            // Assert
            // Verify that the properties of the Name object match the expected values
            Assert.That(name.LastName, Is.EqualTo(expectedLastName), "Last name should match");
            Assert.That(name.GivenNames, Is.EqualTo(expectedGivenNames), "Given names should match");
            Assert.That(name.GivenNames, Is.Not.EqualTo(wrongOrderGivenName), "Given names in wrong order shouldn't match");

        }

        [Test]
        public void Name_Implements_IComparable_Correctly()
        {
            // Arrange
            Name name1 = new Name("Doe", new string[] { "John" });
            Name name2 = new Name("Smith", new string[] { "Alice" });
            Name name3 = new Name("Smith", new string[] { "Betty" });
            Name name4 = new Name("Smith", new string[] { "Alice", "Betty" });
            Name name5 = new Name("Smith", new string[] { "Alice", "Cathy" });

            // Act & Assert
            // Verify that the CompareTo method behaves correctly for different scenarios
            Assert.That(name1.CompareTo(name2) < 0); // Last name comparison Doe < Smith 
            Assert.That(name2.CompareTo(name3) < 0); // Given name comparison for same last name
            Assert.That(name4.CompareTo(name5) < 0); // Multiple given name comparison for same last name and same first given name
        }
    }
}
