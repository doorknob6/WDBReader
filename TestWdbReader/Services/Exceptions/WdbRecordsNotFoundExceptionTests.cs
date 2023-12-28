using WdbReader.Services.Exceptions;

namespace TestWdbReader.Services.Exceptions
{
    [TestClass]
    public class WdbRecordsNotFoundExceptionTests
    {
        #region Tests

        [TestMethod]
        public void TestConstructorEmpty()
        {
            // Arrange
            string message = "No Wdb Records where found.";
            WdbRecordsNotFoundException wdbRecordsNotFoundException = new();

            // Assert
            Assert.AreEqual(message, wdbRecordsNotFoundException.Message);
        }

        [TestMethod]
        public void TestConstructorMessage()
        {
            // Arrange
            string message = "No Wdb Records where found.";
            WdbRecordsNotFoundException wdbRecordsNotFoundException = new(message);

            // Assert
            Assert.AreEqual(message, wdbRecordsNotFoundException.Message);
        }

        [TestMethod]
        public void TestConstructorMessageInnerException()
        {
            // Arrange
            string message = "No Wdb Records where found.";
            Exception exception = new();
            WdbRecordsNotFoundException wdbRecordsNotFoundException = new(message, exception);

            // Assert
            Assert.AreEqual(message, wdbRecordsNotFoundException.Message);
            Assert.AreEqual(exception, wdbRecordsNotFoundException.InnerException);
        }

        #endregion Tests
    }
}
