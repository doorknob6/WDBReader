using Microsoft.Extensions.DependencyInjection;
using TestWdbReader.Helpers;
using WdbReader.Model;
using WdbReader.Services.Contracts;

namespace TestWdbReader.Services
{
    [TestClass]
    public class WdbReaderServiceTests
    {
        #region Fields

        private IServiceProvider? _serviceProvider;

        #endregion Fields

        #region Initialization

        [TestInitialize]
        public void Initialize()
        {
            _serviceProvider = ServiceHelper.GetProvider();
        }

        #endregion Initialization

        #region Tests

        [TestMethod]
        public async Task GetWdbRecords_Pass()
        {
            // Arrange
            DirectoryInfo directory = TestFileHelper.WdbDirectory;
            int expectedCount = 2;
            IServiceProvider services = GetServiceProvider();
            IWdbReaderService service = services.GetRequiredService<IWdbReaderService>();

            // Act
            List<WdbFile> result = await service.GetWdbRecords(directory, services);

            // Assert
            Assert.AreEqual(expectedCount, result.Count);
        }

        #endregion Tests

        #region Accessors

        private IServiceProvider GetServiceProvider()
        {
            Assert.IsNotNull(_serviceProvider);
            return _serviceProvider;
        }

        #endregion Accessors
    }
}
