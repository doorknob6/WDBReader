using WdbReader.Model;
using WdbReader.Options;

namespace WdbReader.Services.Contracts
{
    /// <summary>
    /// The wdb reader service interface.
    /// </summary>
    public interface IWdbReaderService
    {
        #region Properties

        /// <summary>
        /// Gets or Sets the options.
        /// </summary>
        WdbReaderOptions Options { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the wdb records.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="services">The services.</param>
        /// <returns><![CDATA[Task<List<WdbFile>>]]></returns>
        Task<List<WdbFile>> GetWdbRecords(DirectoryInfo directory, IServiceProvider services);

        #endregion Methods
    }
}
