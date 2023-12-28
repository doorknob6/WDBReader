using WdbReader.Services.Exceptions;

namespace TestWdbReader.Services.Exceptions
{
    [TestClass]
    public class WdbHeaderVersionMatchExceptionTests
    {
        #region Tests

        [TestMethod]
        public void TestConstructorEmpty()
        {
            // Arrange
            string message = "The Wdb file header version does not match the given one.";
            WdbHeaderVersionMatchException wdbHeaderVersionMatchException = new();

            // Assert
            Assert.AreEqual(message, wdbHeaderVersionMatchException.Message);
        }

        [TestMethod]
        public void TestConstructorFoundVersionGivenVersion()
        {
            // Arrange
            uint foundVersion = 0;
            uint givenVersion = 1;
            WdbHeaderVersionMatchException wdbHeaderVersionMatchException =
                new(foundVersion, givenVersion);

            string message =
                $"The Wdb file header version '{foundVersion}' "
                + $"does not match the given one '{givenVersion}'.";

            // Assert
            Assert.AreEqual(message, wdbHeaderVersionMatchException.Message);
        }

        [TestMethod]
        public void TestConstructorMessage()
        {
            // Arrange
            string message = "The Wdb file header version does not match the given one.";
            WdbHeaderVersionMatchException wdbHeaderVersionMatchException = new(message);

            // Assert
            Assert.AreEqual(message, wdbHeaderVersionMatchException.Message);
        }

        [TestMethod]
        public void TestConstructorMessageInnerException()
        {
            // Arrange
            string message = "The Wdb file header version does not match the given one.";
            Exception exception = new();
            WdbHeaderVersionMatchException wdbHeaderVersionMatchException = new(message, exception);

            // Assert
            Assert.AreEqual(message, wdbHeaderVersionMatchException.Message);
            Assert.AreEqual(exception, wdbHeaderVersionMatchException.InnerException);
        }

        #endregion Tests
    }
}
