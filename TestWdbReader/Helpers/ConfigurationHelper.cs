using Microsoft.Extensions.Configuration;
using WdbReader.Extensions.Configuration;

namespace TestWdbReader.Helpers
{
    public static class ConfigurationHelper
    {
        #region Methods

        public static IConfiguration GetConfiguration()
        {
            IConfigurationBuilder configuration = new ConfigurationBuilder();

            return configuration.AddWdbReaderConfiguration().Build();
        }

        #endregion Methods
    }
}
