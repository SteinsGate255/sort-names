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
        public void Constructor_ValidArguments_ConstructsObject()
        {
            // Arrange
            string lastName = "Doe";
            string[] givenNames = { "John", "Robert" };

            // Act
            Name name = new Name(lastName, givenNames);

            // Assert
            Assert.That(lastName, Is.EqualTo(name.LastName));
            Assert.That(givenNames, Is.EqualTo(name.GivenNames));
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

        
    }
}
