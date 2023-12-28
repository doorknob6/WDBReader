using TestWdbReader.Helpers;
using WdbReader.Extensions.Text;
using WdbReader.Model;
using WdbReader.Options;

namespace TestWdbReader.Extensions.Text
{
    [TestClass]
    public class WdbReaderBinaryReaderExtensionsTests
    {
        #region Tests

        [TestMethod]
        [DynamicData(nameof(TestFileHelper.InitialStringData), typeof(TestFileHelper))]
        public void ReadString_Pass(BinaryReader reader, int position, string expected)
        {
            // Arrange
            reader.BaseStream.Position = position;
            int count = expected.Length;

            // Act
            var result = reader.ReadString(count);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(TestFileHelper.StringNullData), typeof(TestFileHelper))]
        public void ReadStringNull_Pass(BinaryReader reader, int position, string expected)
        {
            // Arrange
            reader.BaseStream.Position = position;

            // Act
            var result = reader.ReadStringNull();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DynamicData(nameof(TestFileHelper.WdbRecordData), typeof(TestFileHelper))]
        public void ReadWdbRecord_Pass(
            BinaryReader reader,
            int position,
            WdbRecordOptions options,
            WdbRecord expected
        )
        {
            //Arrange
            reader.BaseStream.Position = position;

            // Act
            WdbRecord result = reader.ReadWdbRecord(options);

            // Assert
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.DataType, result.DataType);

            if (expected.Value is not byte[] expectedValues)
            {
                Assert.AreEqual(expected.Value, result.Value);
                return;
            }

            if (result.Value is not byte[] resultValues)
            {
                Assert.AreEqual(expected.Value, result.Value);
                return;
            }
            int i = 0;
            foreach (byte expectedValue in expectedValues)
            {
                Assert.AreEqual(expectedValue, resultValues[i]);
                i++;
            }
            return;
        }

        [TestMethod]
        [DynamicData(nameof(TestFileHelper.WdbRecordEmptyDataTypeData), typeof(TestFileHelper))]
        public void ReadWdbRecordEmptyDataType_Pass(
            BinaryReader reader,
            int position,
            WdbRecordOptions options,
            WdbRecord expected
        )
        {
            //Arrange
            reader.BaseStream.Position = position;

            // Act
            WdbRecord result = reader.ReadWdbRecord(options);

            // Assert
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.DataType, result.DataType);
            Assert.AreEqual(expected.Value, result.Value);
            Assert.AreEqual(null, result.Value);
        }

        #endregion Tests
    }
}
