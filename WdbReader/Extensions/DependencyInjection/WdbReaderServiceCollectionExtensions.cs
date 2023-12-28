using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WdbReader.Options;
using WdbReader.Services;
using WdbReader.Services.Contracts;

namespace WdbReader.Extensions.DependencyInjection
{
    /// <summary>
    /// The wdb reader service collection extensions.
    /// </summary>
    public static class WdbReaderServiceCollectionExtensions
    {
        #region Methods

        /// <summary>
        /// Add wdb reader configuration.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>An IServiceCollection.</returns>
        public static IServiceCollection AddWdbReaderConfiguration(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            return services.Configure<WdbReaderOptions>(
                configuration.GetSection(nameof(WdbReaderOptions))
            );
        }

        /// <summary>
        /// Add wdb reader services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>An IServiceCollection.</returns>
        public static IServiceCollection AddWdbReaderServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IWdbReaderService, WdbReaderService>()
                .AddTransient<IWdbFileReaderService, WdbFileReaderService>()
                .AddTransient<IWdbHeaderService, WdbHeaderService>()
                .AddScoped<IWdbRecordService, WdbRecordService>();
        }

        #endregion Methods
    }
}
