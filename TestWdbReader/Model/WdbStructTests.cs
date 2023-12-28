using WdbReader.Model;

namespace TestWdbReader.Model
{
    [TestClass]
    public class WdbStructTests
    {
        #region Tests

        [TestMethod]
        public void TestConstructor()
        {
            // Arrange
            uint identifier = 1;
            WdbRecordDataType ídentifierDataType = WdbRecordDataType.IntegerType;
            List<WdbRecord> wdbRecords = new();
            WdbStruct wdbStruct = new(identifier, ídentifierDataType, wdbRecords);

            // Assert
            Assert.AreEqual(identifier, wdbStruct.Identifier);
            Assert.AreEqual(ídentifierDataType, wdbStruct.IdentifierType);
            Assert.AreEqual(wdbRecords, wdbStruct.Records);
        }

        #endregion Tests
    }
}
