using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WdbReader.Model;
using WdbReader.Options;
using WdbReader.Services.Contracts;

namespace WdbReader.Services
{
    /// <summary>
    /// The wdb reader service.
    /// </summary>
    public class WdbReaderService : Base.LoggedServiceBase, IWdbReaderService
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbReaderService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="options">The options.</param>
        public WdbReaderService(
            ILogger<WdbReaderService> logger,
            IOptions<WdbReaderOptions> options
        )
            : base(logger)
        {
            Options = options.Value;
        }

        #endregion Constructors

        #region Properties

        /// <inheritdoc/>
        public WdbReaderOptions Options { get; set; }

        #endregion Properties

        #region Methods

        /// <inheritdoc/>
        public async Task<List<WdbFile>> GetWdbRecords(
            DirectoryInfo directory,
            IServiceProvider services
        )
        {
            List<Task<WdbFile>> tasks = new();
            foreach (WdbOptions options in Options.WdbOptions)
            {
                tasks.Add(GetWdbRecords(directory, services, options));
            }
            WdbFile[] files = await Task.WhenAll(tasks);
            return files.ToList();
        }

        /// <summary>
        /// Gets the wdb records.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="services">The services.</param>
        /// <param name="options">The options.</param>
        /// <returns><![CDATA[Task<WdbFile>]]></returns>
        private static async Task<WdbFile> GetWdbRecords(
            DirectoryInfo directory,
            IServiceProvider services,
            WdbOptions options
        )
        {
            using IServiceScope scope = services.CreateScope();
            IWdbFileReaderService wdbFileService =
                scope.ServiceProvider.GetRequiredService<IWdbFileReaderService>();
            return await wdbFileService.ReadWdbFile(directory, options);
        }

        #endregion Methods
    }
}
