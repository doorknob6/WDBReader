using WdbReader.Model;
using WdbReader.Options;

namespace WdbReader.Services.Contracts
{
    /// <summary>
    /// The wdb header service interface.
    /// </summary>
    public interface IWdbHeaderService
    {
        #region Properties

        /// <summary>
        /// Gets the wdb record service.
        /// </summary>
        IWdbRecordService WdbRecordService { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the wdb file.
        /// </summary>
        /// <param name="wdbReader">The wdb reader.</param>
        /// <param name="options">The options.</param>
        /// <returns>A WdbFile.</returns>
        WdbFile GetWdbFile(BinaryReader wdbReader, WdbOptions options);

        #endregion Methods
    }
}
