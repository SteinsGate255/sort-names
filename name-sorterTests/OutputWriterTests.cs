using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter.Tests
{
    public class OutputWriterTests
    {
        [Test]
        public void WriteNamesToConsole_WritesToConsole()
        {
            // Arrange
            List<string> names = new List<string> { "John Doe", "Jane Smith" };
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            OutputWriter.WriteNamesToConsole(names);

            // Assert
            // Verify that names are correctly written to the console
            string expectedOutput = string.Join(Environment.NewLine, names) + Environment.NewLine;
            Assert.That(expectedOutput, Is.EqualTo(sw.ToString()));
        }

        [Test]
        public void WriteNamesToFile_WritesToFile()
        {
            // Arrange
            List<string> names = new List<string> { "John Doe", "Jane Smith" };
            string filePath = "test-output.txt";

            // Act
            OutputWriter.WriteNamesToFile(names, filePath);

            // Assert
            // Verify that names are correctly written to the specified file
            Assert.That(File.Exists(filePath));
            string[] lines = File.ReadAllLines(filePath);
            CollectionAssert.AreEqual(names, lines);
        }
    }
}
