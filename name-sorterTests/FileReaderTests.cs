using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter.Tests
{
    [TestFixture]
    public class FileReaderTests
    {
        private string _validFilePath;
        private string _invalidFilePath;

        [SetUp]
        public void Setup()
        {
            // Set up valid and invalid file paths for testing
            _validFilePath = "valid-names.txt";
            _invalidFilePath = "invalid-file.txt";
        }

        [Test]
        public void ReadNamesFromFile_ValidFilePath_ReturnsNamesList()
        {
            // Arrange
            // Create a valid input file with two names
            File.WriteAllText(_validFilePath, "John Doe\nJane Smith\n");

            // Act
            var names = FileReader.ReadNamesFromFile(_validFilePath);

            // Assert
            // Verify that the names list is not null and contains two names
            Assert.That(names, Is.Not.Null);
            Assert.That(names.Count, Is.EqualTo(2));
            // Verify that the names are correctly read from the file
            Assert.That(names[0], Is.EqualTo("John Doe"));
            Assert.That(names[1], Is.EqualTo("Jane Smith"));
        }

        [Test]
        public void ReadNamesFromFile_InvalidFilePath_ThrowsException()
        {
            // Act & Assert
            // Verify that reading from an invalid file path throws a FileNotFoundException
            TestDelegate testDelegate = () => FileReader.ReadNamesFromFile(_invalidFilePath);
            Assert.That(testDelegate, Throws.Exception.TypeOf<FileNotFoundException>());
        }

        [Test]
        public void ReadNamesFromFile_NullFilePath_ThrowsException()
        {
            // Act & Assert
            // Verify that passing a null file path throws an ArgumentNullException
            Assert.Throws<ArgumentNullException>(() => FileReader.ReadNamesFromFile(null));
        }

        [Test]
        public void ReadNamesFromFile_EmptyFilePath_ThrowsException()
        {
            // Arrange
            string emptyFilePath = string.Empty;

            // Act & Assert
            // Verify that passing an empty file path throws an ArgumentException
            Assert.Throws<ArgumentException>(() => FileReader.ReadNamesFromFile(emptyFilePath));
        }

        [Test]
        public void ReadNamesFromFile_EmptyFile_ThrowsException()
        {
            // Arrange
            string emptyFilePath = "empty-file.txt";
            // Create an empty input file
            File.WriteAllText(emptyFilePath, string.Empty);

            // Act & Assert
            // Verify that reading from an empty file throws an Exception
            Assert.Throws<Exception>(() => FileReader.ReadNamesFromFile(emptyFilePath));
        }
    }
}
