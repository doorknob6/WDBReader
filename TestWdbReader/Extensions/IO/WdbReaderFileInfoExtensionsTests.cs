using TestWdbReader.Helpers;
using WdbReader.Extensions.IO;

namespace TestWdbReader.Extensions.IO
{
    [TestClass]
    public class WdbReaderFileInfoExtensionsTests
    {
        #region Tests

        [TestMethod]
        [DynamicData(nameof(TestFileHelper.LengthData), typeof(TestFileHelper))]
        public void ReadAllBytes_Pass(FileInfo fileInfo, int length)
        {
            // Act
            byte[] bytes = fileInfo.ReadAllBytes();

            // Assert
            Assert.AreEqual(length, bytes.Length);
        }

        [TestMethod]
        [DynamicData(nameof(TestFileHelper.LengthData), typeof(TestFileHelper))]
        public void ToBinaryReader_Pass(FileInfo fileInfo, int length)
        {
            // Act
            BinaryReader reader = fileInfo.ToBinaryReader();

            // Assert
            Assert.AreEqual(length, reader.BaseStream.Length);
        }

        [TestMethod]
        [DynamicData(nameof(TestFileHelper.LengthData), typeof(TestFileHelper))]
        public void ToByteMemoryStream_Pass(FileInfo fileInfo, int length)
        {
            // Act
            using MemoryStream ms = fileInfo.ToByteMemoryStream();

            // Assert
            Assert.AreEqual(length, ms.Length);
        }

        #endregion Tests
    }
}
