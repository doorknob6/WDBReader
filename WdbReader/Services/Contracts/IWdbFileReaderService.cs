using WdbReader.Model;
using WdbReader.Options;

namespace WdbReader.Services.Contracts
{
    /// <summary>
    /// The wdb file reader service interface.
    /// </summary>
    public interface IWdbFileReaderService
    {
        #region Properties

        /// <summary>
        /// Gets the wdb header service.
        /// </summary>
        IWdbHeaderService WdbHeaderService { get; }

        /// <summary>
        /// Gets the wdb record service.
        /// </summary>
        IWdbRecordService WdbRecordService { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Reads the wdb file.
        /// </summary>
        /// <remarks>
        /// This method should look for the file with the given name in the given folder and subfolders.
        /// </remarks>
        /// <param name="directory">The directory.</param>
        /// <param name="options">The options.</param>
        /// <returns><![CDATA[Task<WdbFile>]]></returns>
        Task<WdbFile> ReadWdbFile(DirectoryInfo directory, WdbOptions options);

        #endregion Methods
    }
}
