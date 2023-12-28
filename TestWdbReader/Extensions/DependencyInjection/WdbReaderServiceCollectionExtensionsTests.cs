using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Options;
using TestWdbReader.Helpers;
using WdbReader.Extensions.DependencyInjection;
using WdbReader.Options;
using WdbReader.Services.Contracts;

namespace TestWdbReader.Extensions.DependencyInjection
{
    [TestClass]
    public class WdbReaderServiceCollectionExtensionsTests
    {
        #region Fields

        private IConfiguration? _configuration;

        #endregion Fields

        #region Initialization

        [TestInitialize]
        public void Initialize()
        {
            _configuration = ConfigurationHelper.GetConfiguration();
        }

        #endregion Initialization

        #region Tests

        /// <summary>
        /// This test tests the <see
        /// cref="WdbReaderServiceCollectionExtensions.AddWdbReaderConfiguration"/> extension method.
        /// </summary>
        /// <remarks>This uses the 'wdbsettings.json' to obtain its configuration data.</remarks>
        [TestMethod]
        public void AddWdbReaderConfiguration_Pass()
        {
            // Arrange
            IServiceProvider services = GetServiceCollection()
                .AddWdbReaderConfiguration(GetConfiguration())
                .BuildServiceProvider();

            // Act
            IOptions<WdbReaderOptions> options = services.GetRequiredService<
                IOptions<WdbReaderOptions>
            >();

            // Assert
            Assert.IsTrue(options.Value is not null);
        }

        [TestMethod]
        public void AddWdbReaderServices_Pass()
        {
            // Arrange
            IServiceProvider services = GetServiceCollection()
                .AddWdbReaderServices()
                .AddLogging(
                    builder =>
                        builder
                            .AddProvider(new DebugLoggerProvider())
                            .SetMinimumLevel(LogLevel.Debug)
                )
                .BuildServiceProvider();

            // Act
            using IServiceScope scope = services.CreateScope();
            IWdbReaderService wdbReaderService =
                scope.ServiceProvider.GetRequiredService<IWdbReaderService>();
            IWdbFileReaderService wdbFileReaderService =
                scope.ServiceProvider.GetRequiredService<IWdbFileReaderService>();
            IWdbHeaderService wdbHeaderService =
                scope.ServiceProvider.GetRequiredService<IWdbHeaderService>();
            IWdbRecordService wdbRecordService =
                scope.ServiceProvider.GetRequiredService<IWdbRecordService>();

            // Assert exist
            Assert.IsNotNull(wdbReaderService);
            Assert.IsNotNull(wdbFileReaderService);
            Assert.IsNotNull(wdbHeaderService);
            Assert.IsNotNull(wdbRecordService);

            // check service scopes
            Assert.AreNotEqual(wdbFileReaderService.WdbHeaderService, wdbHeaderService);
            Assert.AreEqual(
                wdbFileReaderService.WdbRecordService,
                wdbHeaderService.WdbRecordService
            );
            Assert.AreEqual(wdbFileReaderService.WdbRecordService, wdbRecordService);
        }

        #endregion Tests

        #region Accessors

        private static IServiceCollection GetServiceCollection()
        {
            return new ServiceCollection().AddTestWdbReaderOptions();
        }

        private IConfiguration GetConfiguration()
        {
            Guard.IsNotNull(_configuration);
            return _configuration;
        }

        #endregion Accessors
    }
}
