using WdbReader.Services.Exceptions;

namespace TestWdbReader.Services.Exceptions
{
    [TestClass]
    public class WdbHeaderSignatureMatchExceptionTests
    {
        #region Tests

        [TestMethod]
        public void TestConstructorEmpty()
        {
            // Arrange
            string message = "The Wdb file header signature does not match the given one.";
            WdbHeaderSignatureMatchException wdbHeaderSignatureMatchException = new();

            // Assert
            Assert.AreEqual(message, wdbHeaderSignatureMatchException.Message);
        }

        [TestMethod]
        public void TestConstructorFoundSignatureGivenSignature()
        {
            // Arrange
            string foundSignature = "test";
            string givenSignature = "test_";
            WdbHeaderSignatureMatchException wdbHeaderSignatureMatchException =
                new(foundSignature, givenSignature);

            string message =
                $"The Wdb file header signature '{foundSignature}' "
                + $"does not match the given one '{givenSignature}'.";

            // Assert
            Assert.AreEqual(message, wdbHeaderSignatureMatchException.Message);
        }

        [TestMethod]
        public void TestConstructorMessageInnerException()
        {
            // Arrange
            string message = "The Wdb file header signature does not match the given one.";
            Exception exception = new();
            WdbHeaderSignatureMatchException wdbHeaderSignatureMatchException =
                new(message, exception);

            // Assert
            Assert.AreEqual(message, wdbHeaderSignatureMatchException.Message);
            Assert.AreEqual(exception, wdbHeaderSignatureMatchException.InnerException);
        }

        [TestMethod]
        public void TestConstructorSignature()
        {
            // Arrange
            string signature = "test";
            WdbHeaderSignatureMatchException wdbHeaderSignatureMatchException = new(signature);

            string message =
                $"The Wdb file header signature does not match the given one '{signature}'.";

            // Assert
            Assert.AreEqual(message, wdbHeaderSignatureMatchException.Message);
        }

        #endregion Tests
    }
}
