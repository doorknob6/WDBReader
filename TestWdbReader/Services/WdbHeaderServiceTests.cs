using TestWdbReader.Helpers;
using WdbReader.Model;
using WdbReader.Options;
using WdbReader.Services.Contracts;
using WdbReader.Services.Exceptions;

namespace TestWdbReader.Services
{
    [TestClass]
    public class WdbHeaderServiceTests
    {
        #region Fields

        private IWdbHeaderService? _service;

        #endregion Fields

        #region Initialization

        [TestInitialize]
        public void Initialize()
        {
            _service = ServiceHelper.GetRequiredService<IWdbHeaderService>();
        }

        #endregion Initialization

        #region Tests

        [TestMethod]
        [DynamicData(nameof(TestFileHelper.WdbHeaderSignatureMismatchData), typeof(TestFileHelper))]
        public void GetWdbFile_HeaderSignatureMismatch_Pass(
            BinaryReader wdbReader,
            int position,
            WdbOptions options
        )
        {
            // Arrange
            wdbReader.BaseStream.Position = position;
            IWdbHeaderService service = GetService();

            // Act
            Assert.ThrowsException<WdbHeaderSignatureMatchException>(
                () => service.GetWdbFile(wdbReader, options)
            );
        }

        [TestMethod]
        [DynamicData(nameof(TestFileHelper.WdbHeaderVersionMismatchData), typeof(TestFileHelper))]
        public void GetWdbFile_HeaderVersionMismatch_Pass(
            BinaryReader wdbReader,
            int position,
            WdbOptions options
        )
        {
            // Arrange
            wdbReader.BaseStream.Position = position;
            IWdbHeaderService service = GetService();

            // Act
            Assert.ThrowsException<WdbHeaderVersionMatchException>(
                () => service.GetWdbFile(wdbReader, options)
            );
        }

        [TestMethod]
        [DynamicData(nameof(TestFileHelper.WdbHeaderEmptyData), typeof(TestFileHelper))]
        public void GetWdbFile_RecordsNotPresent_Pass(
            BinaryReader wdbReader,
            int position,
            WdbOptions options
        )
        {
            // Arrange
            wdbReader.BaseStream.Position = position;
            IWdbHeaderService service = GetService();

            // Act
            Assert.ThrowsException<WdbRecordsNotFoundException>(
                () => service.GetWdbFile(wdbReader, options)
            );
        }

        [TestMethod]
        [DynamicData(nameof(TestFileHelper.WdbHeaderData), typeof(TestFileHelper))]
        public void GetWdbFile_RecordsPresent_Pass(
            BinaryReader wdbReader,
            int position,
            WdbOptions options,
            WdbFile expected
        )
        {
            // Arrange
            wdbReader.BaseStream.Position = position;
            IWdbHeaderService service = GetService();

            // Act
            WdbFile result = service.GetWdbFile(wdbReader, options);

            // Assert
            Assert.AreEqual(options.FileName, expected.Name);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Locale, result.Locale);
            Assert.AreEqual(expected.Signature, result.Signature);
            Assert.AreEqual(expected.Version, result.Version);
            Assert.AreEqual(expected.RecordSize, result.RecordSize);
            Assert.AreEqual(expected.RecordVersion, result.RecordVersion);
        }

        #endregion Tests

        #region Accessors

        private IWdbHeaderService GetService()
        {
            Assert.IsNotNull(_service);
            return _service;
        }

        #endregion Accessors
    }
}
