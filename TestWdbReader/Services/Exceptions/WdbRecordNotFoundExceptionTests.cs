using WdbReader.Services.Exceptions;

namespace TestWdbReader.Services.Exceptions
{
    [TestClass]
    public class WdbRecordNotFoundExceptionTests
    {
        #region Tests

        [TestMethod]
        public void TestConstructorEmpty()
        {
            // Arrange
            string message = "A record was requested by name and not found.";
            WdbRecordNotFoundException wdbRecordNotFoundException = new();

            // Assert
            Assert.AreEqual(message, wdbRecordNotFoundException.Message);
        }

        [TestMethod]
        public void TestConstructorMessageInnerException()
        {
            // Arrange
            string message = "A record was requested by name and not found.";
            Exception exception = new();
            WdbRecordNotFoundException wdbRecordNotFoundException = new(message, exception);

            // Assert
            Assert.AreEqual(message, wdbRecordNotFoundException.Message);
            Assert.AreEqual(exception, wdbRecordNotFoundException.InnerException);
        }

        [TestMethod]
        public void TestConstructorName()
        {
            // Arrange
            string name = "test";
            WdbRecordNotFoundException wdbRecordNotFoundException = new(name);

            string message = $"A record was requested by name '{name}' and not found.";

            // Assert
            Assert.AreEqual(message, wdbRecordNotFoundException.Message);
        }

        #endregion Tests
    }
}
