using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using WdbReader.Extensions.DependencyInjection;

namespace TestWdbReader.Helpers
{
    /// <summary>
    /// The service helper.
    /// </summary>
    internal static class ServiceHelper
    {
        #region Methods

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <remarks>
        /// Creates a <see cref="IServiceProvider"/> with services as defined in <see cref="WdbReader.Extensions.DependencyInjection"/>
        /// </remarks>
        /// <returns>An IServiceProvider.</returns>
        public static IServiceProvider GetProvider()
        {
            ServiceCollection services = new();
            return services
                .AddTestWdbReaderOptions()
                .AddLogging(
                    builder =>
                        builder
                            .AddProvider(new DebugLoggerProvider())
                            .SetMinimumLevel(LogLevel.Debug)
                )
                .AddWdbReaderServices()
                .BuildServiceProvider();
        }

        /// <summary>
        /// Gets the required service from dependency injection container.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>A <typeparamref name="T"></typeparamref></returns>
        public static T GetRequiredService<T>()
            where T : notnull
        {
            IServiceProvider services = GetProvider();
            return services.GetRequiredService<T>();
        }

        #endregion Methods
    }
}
