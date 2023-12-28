using TestWdbReader.Helpers;
using WdbReader.Model;
using WdbReader.Options;
using WdbReader.Services.Contracts;
using WdbReader.Services.Exceptions;

namespace TestWdbReader.Services
{
    [TestClass]
    public class WdbFileReaderServiceTests
    {
        #region Fields

        private IWdbFileReaderService? _service;

        #endregion Fields

        #region Initialization

        [TestInitialize]
        public void Initialize()
        {
            _service = ServiceHelper.GetRequiredService<IWdbFileReaderService>();
        }

        #endregion Initialization

        #region Tests

        [TestMethod]
        [DynamicData(nameof(TestFileHelper.WdbDirectoryNotFoundData), typeof(TestFileHelper))]
        public async Task ReadWdbFile_DirectoryNotPresent_Pass(
            DirectoryInfo directory,
            WdbOptions options
        )
        {
            // Arrange
            IWdbFileReaderService service = GetService();

            // Act
            await Assert.ThrowsExceptionAsync<DirectoryNotFoundException>(
                () => service.ReadWdbFile(directory, options)
            );
        }

        [TestMethod]
        [DynamicData(nameof(TestFileHelper.WdbFileDoubleData), typeof(TestFileHelper))]
        public async Task ReadWdbFile_FileDouble_Pass(DirectoryInfo directory, WdbOptions options)
        {
            // Arrange
            IWdbFileReaderService service = GetService();

            // Act
            await Assert.ThrowsExceptionAsync<MultipleFilesFoundException>(
                () => service.ReadWdbFile(directory, options)
            );
        }

        [TestMethod]
        [DynamicData(nameof(TestFileHelper.WdbFileNotFoundData), typeof(TestFileHelper))]
        public async Task ReadWdbFile_FileNotPresent_Pass(
            DirectoryInfo directory,
            WdbOptions options
        )
        {
            // Arrange
            IWdbFileReaderService service = GetService();

            // Act
            await Assert.ThrowsExceptionAsync<FileNotFoundException>(
                () => service.ReadWdbFile(directory, options)
            );
        }

        [TestMethod]
        [DynamicData(nameof(TestFileHelper.WdbFileData), typeof(TestFileHelper))]
        public async Task ReadWdbFile_FilePresent_Pass(
            DirectoryInfo directory,
            WdbOptions options,
            WdbFile expected,
            int expectedItemsCount
        )
        {
            // Arrange
            IWdbFileReaderService service = GetService();

            // Act
            WdbFile result = await service.ReadWdbFile(directory, options);

            // Assert Assert
            Assert.AreEqual(options.FileName, expected.Name);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Locale, result.Locale);
            Assert.AreEqual(expected.Signature, result.Signature);
            Assert.AreEqual(expected.Version, result.Version);
            Assert.AreEqual(expected.RecordSize, result.RecordSize);
            Assert.AreEqual(expected.RecordVersion, result.RecordVersion);
            Assert.AreEqual(expectedItemsCount, result.Items.Count);
        }

        #endregion Tests

        #region Accessors

        private IWdbFileReaderService GetService()
        {
            Assert.IsNotNull(_service);
            return _service;
        }

        #endregion Accessors
    }
}
