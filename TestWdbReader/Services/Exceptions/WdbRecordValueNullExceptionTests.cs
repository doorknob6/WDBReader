using WdbReader.Services.Exceptions;

namespace TestWdbReader.Services.Exceptions
{
    [TestClass]
    public class WdbRecordValueNullExceptionTests
    {
        #region Tests

        [TestMethod]
        public void TestConstructorEmpty()
        {
            // Arrange
            string message = "The requested wdb records value is null.";
            WdbRecordValueNullException wdbRecordValueNullException = new();

            // Assert
            Assert.AreEqual(message, wdbRecordValueNullException.Message);
        }

        [TestMethod]
        public void TestConstructorMessageInnerException()
        {
            // Arrange
            string message = "The requested wdb records value is null.";
            Exception exception = new();
            WdbRecordValueNullException wdbRecordValueNullException = new(message, exception);

            // Assert
            Assert.AreEqual(message, wdbRecordValueNullException.Message);
            Assert.AreEqual(exception, wdbRecordValueNullException.InnerException);
        }

        [TestMethod]
        public void TestConstructorName()
        {
            // Arrange
            string name = "test";
            WdbRecordValueNullException wdbRecordValueNullException = new(name);

            string message = $"The requested wdb record '{name}' value is null";

            // Assert
            Assert.AreEqual(message, wdbRecordValueNullException.Message);
        }

        #endregion Tests
    }
}
