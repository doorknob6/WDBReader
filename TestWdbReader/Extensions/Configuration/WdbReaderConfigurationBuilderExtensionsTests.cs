using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using WdbReader.Extensions.Configuration;

namespace TestWdbReader.Extensions.Configuration
{
    /// <summary>
    /// The wdb reader configuration builder extensions tests.
    /// </summary>
    [TestClass]
    public class WdbReaderConfigurationBuilderExtensionsTests
    {
        #region Tests

        [TestMethod]
        public void AddWdbReaderConfiguration_BaseCase_Pass()
        {
            // Arrange
            IConfigurationBuilder builder = new ConfigurationBuilder();

            // Act
            _ = builder.AddWdbReaderConfiguration();
            JsonConfigurationSource? firstSource =
                builder.Sources.First() as JsonConfigurationSource;

            if (firstSource is null)
            {
                Assert.Fail(
                    "The added configuration source '{Source}' is not of type '{Type}'",
                    firstSource,
                    typeof(JsonConfigurationSource)
                );
            }

            // Assert
            Assert.AreEqual(firstSource.Path, "wdbsettings.json");
        }

        #endregion Tests
    }
}
