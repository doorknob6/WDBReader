using Microsoft.Extensions.Logging;
using WdbReader.Model;
using WdbReader.Options;
using WdbReader.Services.Contracts;
using WdbReader.Services.Exceptions;

namespace WdbReader.Services
{
    /// <summary>
    /// The wdb header service.
    /// </summary>
    public class WdbHeaderService : Base.LoggedServiceBase, IWdbHeaderService
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbHeaderService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="wdbRecordService">The wdb record service.</param>
        public WdbHeaderService(
            ILogger<WdbHeaderService> logger,
            IWdbRecordService wdbRecordService
        )
            : base(logger)
        {
            WdbRecordService = wdbRecordService;
        }

        #endregion Constructors

        #region Properties

        /// <inheritdoc/>
        public IWdbRecordService WdbRecordService { get; }

        #endregion Properties

        #region Methods

        /// <inheritdoc/>
        public WdbFile GetWdbFile(BinaryReader wdbReader, WdbOptions options)
        {
            List<WdbRecord>? records = WdbRecordService.GetRecords(
                wdbReader,
                options.HeaderOptions
            );
            if (records?.Any() != true)
            {
                throw new WdbRecordsNotFoundException();
            }
            string signature = MatchHeaderSignature(records, options.HeaderOptions);
            uint version = MatchHeaderVersion(records, options.HeaderOptions);
            WdbFile wdbFile =
                new(
                    options.FileName,
                    signature,
                    WdbRecordService.GetRecordValueStringNotNull(records, nameof(WdbFile.Locale)),
                    version,
                    WdbRecordService.GetRecordValueIntNotNull(records, nameof(WdbFile.RecordSize)),
                    WdbRecordService.GetRecordValueIntNotNull(
                        records,
                        nameof(WdbFile.RecordVersion)
                    )
                );
            Logger.LogInformation(
                "WdbFile added: name = '{Name}', "
                    + "signature = '{Signature}', "
                    + "locale = '{Locale}', "
                    + "version = '{Version}', "
                    + "record size = '{RecordSize}', "
                    + "record version = '{RecordVersion}'",
                wdbFile.Name,
                signature,
                wdbFile.Locale,
                version,
                wdbFile.RecordSize,
                wdbFile.RecordVersion
            );
            return wdbFile;
        }

        /// <summary>
        /// Match header signature.
        /// </summary>
        /// <param name="records">The records.</param>
        /// <param name="options">The options.</param>
        /// <exception cref="WdbHeaderSignatureMatchException"></exception>
        private string MatchHeaderSignature(List<WdbRecord> records, WdbHeaderOptions options)
        {
            string signature = WdbRecordService.GetRecordValueStringNotNull(
                records,
                nameof(WdbFile.Signature)
            );
            if (signature != options.Signature)
            {
                throw new WdbHeaderSignatureMatchException(signature, options.Signature);
            }
            Logger.LogDebug(
                "Matched found header signature '{FoundSignature}' to given signature '{GivenSignature}'",
                signature,
                options.Signature
            );
            return signature;
        }

        /// <summary>
        /// Match header version.
        /// </summary>
        /// <param name="records">The records.</param>
        /// <param name="options">The options.</param>
        /// <exception cref="WdbHeaderVersionMatchException"></exception>
        /// <returns>An uint.</returns>
        private uint MatchHeaderVersion(List<WdbRecord> records, WdbHeaderOptions options)
        {
            uint version = WdbRecordService.GetRecordValueIntNotNull(
                records,
                nameof(WdbFile.Version)
            );
            if (version != options.Version)
            {
                throw new WdbHeaderVersionMatchException(version, options.Version);
            }
            Logger.LogDebug(
                "Matched found header version '{FoundVersion}' to given version '{GivenVersion}'",
                version,
                options.Version
            );
            return version;
        }

        #endregion Methods
    }
}
