using WdbReader.Model;
using WdbReader.Model.Exceptions;

namespace TestWdbReader.Model.Exceptions
{
    [TestClass]
    public class WdbRecordValueTypeExceptionTests
    {
        #region Tests

        [TestMethod]
        public void TestConstructorEmpty()
        {
            // Arrange
            WdbRecordValueTypeException wdbRecordValueTypeException = new();

            // Assert
            Assert.AreEqual(
                "The requested value type does not match this wdb records value type.",
                wdbRecordValueTypeException.Message
            );
        }

        [TestMethod]
        public void TestConstructorMessage()
        {
            // Arrange
            string message = "test";
            WdbRecordValueTypeException wdbRecordValueTypeException = new(message);

            // Assert
            Assert.AreEqual(message, wdbRecordValueTypeException.Message);
        }

        [TestMethod]
        public void TestConstructorMessageInnerException()
        {
            // Arrange
            string message = "test";
            Exception exception = new();
            WdbRecordValueTypeException wdbRecordValueTypeException = new(message, exception);

            // Assert
            Assert.AreEqual(message, wdbRecordValueTypeException.Message);
            Assert.AreEqual(exception, wdbRecordValueTypeException.InnerException);
        }

        [TestMethod]
        public void TestConstructorRequestedTypeValueType()
        {
            // Arrange
            Type requestedType = typeof(uint);
            WdbRecordDataType valueType = WdbRecordDataType.FloatType;
            WdbRecordValueTypeException wdbRecordValueTypeException = new(requestedType, valueType);

            // Assert
            Assert.AreEqual(
                $"The requested value type '{requestedType}' "
                    + $"does not match this wdb records value type '{valueType}'.",
                wdbRecordValueTypeException.Message
            );
        }

        #endregion Tests
    }
}
