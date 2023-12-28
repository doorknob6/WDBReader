using WdbReader.Model;
using WdbReader.Model.Exceptions;

namespace TestWdbReader.Model
{
    [TestClass]
    public class WdbRecordTests
    {
        #region Tests

        #region GetBitMaskValue

        [TestMethod]
        public void GetBitMaskValue_BitMaskValue_Pass()
        {
            // Arrange
            byte[] expected = new byte[] { 255, 255, 255, 255 };
            WdbRecord wdbRecord = new("AllowableClass", expected, WdbRecordDataType.BitMaskType);

            // Act
            byte[]? result = wdbRecord.GetBitMaskValue();

            // Assert
            Assert.IsNotNull(result);
            int i = 0;
            foreach (byte expectedValue in expected)
            {
                Assert.AreEqual(expectedValue, result[i]);
                i++;
            }
            return;
        }

        [TestMethod]
        public void GetBitMaskValue_NonBitMaskValue_Pass()
        {
            // Arrange
            float expected = 64f;
            WdbRecord wdbRecord = new("Damage3Max", expected, WdbRecordDataType.FloatType);

            // Act
            Assert.ThrowsException<WdbRecordValueTypeException>(() => wdbRecord.GetBitMaskValue());
        }

        #endregion GetBitMaskValue

        #region GetFloatValue

        [TestMethod]
        public void GetFloatValue_FloatValue_ExpectedBehavior()
        {
            // Arrange
            float expected = 64f;
            WdbRecord wdbRecord = new("Damage3Max", expected, WdbRecordDataType.FloatType);

            // Act
            float? result = wdbRecord.GetFloatValue();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetFloatValue_NonFloatValue_ExpectedBehavior()
        {
            // Arrange
            uint expected = 2300u;
            WdbRecord wdbRecord = new("WeaponDelay", expected, WdbRecordDataType.IntegerType);

            // Act
            Assert.ThrowsException<WdbRecordValueTypeException>(() => wdbRecord.GetFloatValue());
        }

        #endregion GetFloatValue

        #region GetIntValue

        [TestMethod]
        public void GetIntValue_IntValue_ExpectedBehavior()
        {
            // Arrange
            uint expected = 2300u;
            WdbRecord wdbRecord = new("WeaponDelay", expected, WdbRecordDataType.IntegerType);

            // Act
            var result = wdbRecord.GetIntValue();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetIntValue_NonIntValue_ExpectedBehavior()
        {
            // Arrange
            string expected = "test";
            WdbRecord wdbRecord = new("Description", expected, WdbRecordDataType.StringType);

            // Act
            Assert.ThrowsException<WdbRecordValueTypeException>(() => wdbRecord.GetIntValue());
        }

        #endregion GetIntValue

        #region GetStringValue

        [TestMethod]
        public void GetStringValue_NonStringValue_ExpectedBehavior()
        {
            // Arrange
            uint expected = 2300u;
            WdbRecord wdbRecord = new("WeaponDelay", expected, WdbRecordDataType.IntegerType);

            // Act
            Assert.ThrowsException<WdbRecordValueTypeException>(() => wdbRecord.GetStringValue());
        }

        [TestMethod]
        public void GetStringValue_StringValue_ExpectedBehavior()
        {
            // Arrange
            string expected = "test";
            WdbRecord wdbRecord = new("Description", expected, WdbRecordDataType.StringType);

            // Act
            var result = wdbRecord.GetStringValue();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        #endregion GetStringValue

        #endregion Tests
    }
}
