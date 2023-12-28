using WdbReader.Services.Exceptions;

namespace TestWdbReader.Services.Exceptions
{
    [TestClass]
    public class MultipleFilesFoundExceptionTests
    {
        #region Tests

        [TestMethod]
        public void TestConstructorDirectoryInfoFileNameInnerExceptionNotNull()
        {
            // Arrange
            DirectoryInfo directory = new("test");
            string fileName = "test";
            Exception? innerException = new();
            MultipleFilesFoundException multipleFilesFoundException =
                new(directory, fileName, innerException);

            string message =
                $"Multiple files with name '{fileName}' found in directory "
                + $"'{directory.Name}', where only one was expected.";

            // Assert
            Assert.AreEqual(message, multipleFilesFoundException.Message);
            Assert.AreEqual(innerException, multipleFilesFoundException.InnerException);
        }

        [TestMethod]
        public void TestConstructorDirectoryInfoFileNameInnerExceptionNull()
        {
            // Arrange
            DirectoryInfo directory = new("test");
            string fileName = "test";
            Exception? innerException = null;
            MultipleFilesFoundException multipleFilesFoundException =
                new(directory, fileName, innerException);

            string message =
                $"Multiple files with name '{fileName}' found in directory "
                + $"'{directory.Name}', where only one was expected.";

            // Assert
            Assert.AreEqual(message, multipleFilesFoundException.Message);
            Assert.AreEqual(innerException, multipleFilesFoundException.InnerException);
        }

        [TestMethod]
        public void TestConstructorEmpty()
        {
            // Arrange
            string message = "Multiple files found where only one was expected.";
            MultipleFilesFoundException multipleFilesFoundException = new();

            // Assert
            Assert.AreEqual(message, multipleFilesFoundException.Message);
        }

        [TestMethod]
        public void TestConstructorMessage()
        {
            // Arrange
            string message = "Multiple files found where only one was expected.";
            MultipleFilesFoundException multipleFilesFoundException = new(message);

            // Assert
            Assert.AreEqual(message, multipleFilesFoundException.Message);
        }

        [TestMethod]
        public void TestConstructorMessageInnerException()
        {
            // Arrange
            string message = "Multiple files found where only one was expected.";
            Exception exception = new();
            MultipleFilesFoundException multipleFilesFoundException = new(message, exception);

            // Assert
            Assert.AreEqual(message, multipleFilesFoundException.Message);
            Assert.AreEqual(exception, multipleFilesFoundException.InnerException);
        }

        #endregion Tests
    }
}
