using Microsoft.Extensions.Logging;
using WdbReader.Extensions.IO;
using WdbReader.Model;
using WdbReader.Options;
using WdbReader.Services.Contracts;
using WdbReader.Services.Exceptions;

namespace WdbReader.Services
{
    /// <summary>
    /// The wdb file reader service.
    /// </summary>
    public class WdbFileReaderService : Base.LoggedServiceBase, IWdbFileReaderService
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbFileReaderService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="wdbHeaderService">The wdb header service.</param>
        /// <param name="wdbRecordService">The wdb record service.</param>
        public WdbFileReaderService(
            ILogger<WdbFileReaderService> logger,
            IWdbHeaderService wdbHeaderService,
            IWdbRecordService wdbRecordService
        )
            : base(logger)
        {
            WdbHeaderService = wdbHeaderService;
            WdbRecordService = wdbRecordService;
        }

        #endregion Constructors

        #region Properties

        /// <inheritdoc/>
        public IWdbHeaderService WdbHeaderService { get; }

        /// <inheritdoc/>
        public IWdbRecordService WdbRecordService { get; }

        #endregion Properties

        #region Methods

        /// <inheritdoc/>
        public async Task<WdbFile> ReadWdbFile(DirectoryInfo directory, WdbOptions options)
        {
            if (!directory.Exists)
            {
                throw new DirectoryNotFoundException(directory.FullName);
            }
            FileInfo file = GetWdbFile(directory, options);
            using BinaryReader wdbReader = await Task.Run(file.ToBinaryReader);
            WdbFile wdbFile = WdbHeaderService.GetWdbFile(wdbReader, options);
            List<WdbStruct> structs = ReadWdbStructs(wdbReader, options).ToList();
            wdbFile.Items.AddRange(structs);
            Logger.LogInformation("found {Count} record structs in the wdb file.", structs.Count);
            return wdbFile;
        }

        /// <summary>
        /// Gets the wdb file.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="options">The options.</param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="MultipleFilesFoundException"></exception>
        /// <returns>A FileInfo.</returns>
        private FileInfo GetWdbFile(DirectoryInfo directory, WdbOptions options)
        {
            try
            {
                FileInfo file =
                    directory
                        .GetFiles(options.FileName, SearchOption.AllDirectories)
                        .SingleOrDefault()
                    ?? throw new FileNotFoundException(null, options.FileName);
                ;
                Logger.LogDebug(
                    "found wdb file '{Name}' in directory '{Directory}'",
                    file.Name,
                    file.DirectoryName
                );
                return file;
            }
            catch (InvalidOperationException ex)
            {
                throw new MultipleFilesFoundException(directory, options.FileName, ex);
            }
        }

        /// <summary>
        /// Reads the wdb structs.
        /// </summary>
        /// <param name="wdbReader">The wdb reader.</param>
        /// <param name="options">The options.</param>
        /// <exception cref="WdbRecordValueNullException"></exception>
        /// <returns><![CDATA[List<WdbStruct>]]></returns>
        private IEnumerable<WdbStruct> ReadWdbStructs(
            BinaryReader wdbReader,
            WdbStructOptions options
        )
        {
            while (wdbReader.BaseStream.Position != wdbReader.BaseStream.Length)
            {
                long position = wdbReader.BaseStream.Position;
                if (
                    WdbRecordService.GetRecords(wdbReader, options) is List<WdbRecord> records
                    && records.Any()
                )
                {
                    WdbRecord identifier = WdbRecordService.GetRecord(
                        records,
                        nameof(WdbStruct.Identifier)
                    );
                    object idValue =
                        identifier.Value ?? throw new WdbRecordValueNullException(identifier.Name);
                    WdbStruct wdbStruct = new(idValue, identifier.DataType, records);

                    Logger.LogDebug("{Position}: Added struct '{Identifier}'", position, idValue);

                    yield return wdbStruct;
                }
                else
                {
                    yield break;
                }
            }
        }

        #endregion Methods
    }
}
