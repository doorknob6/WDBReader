using Microsoft.Extensions.Configuration;

namespace WdbReader.Extensions.Configuration
{
    /// <summary>
    /// The wdb reader configuration builder extensions.
    /// </summary>
    public static class WdbReaderConfigurationBuilderExtensions
    {
        #region Methods

        /// <summary>
        /// Add wdb reader configuration.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>An IConfigurationBuilder.</returns>
        public static IConfigurationBuilder AddWdbReaderConfiguration(
            this IConfigurationBuilder builder
        )
        {
            return builder.AddJsonFile("wdbsettings.json");
        }

        #endregion Methods
    }
}
