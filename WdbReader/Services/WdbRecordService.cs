using Microsoft.Extensions.Logging;
using WdbReader.Extensions.Text;
using WdbReader.Model;
using WdbReader.Options;
using WdbReader.Services.Contracts;
using WdbReader.Services.Exceptions;

namespace WdbReader.Services
{
    /// <summary>
    /// The wdb record service.
    /// </summary>
    public class WdbRecordService : Base.LoggedServiceBase, IWdbRecordService
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbRecordService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public WdbRecordService(ILogger<WdbRecordService> logger)
            : base(logger) { }

        #endregion Constructors

        #region Methods

        /// <inheritdoc/>
        public WdbRecord GetRecord(IEnumerable<WdbRecord> records, string name)
        {
            return records.FirstOrDefault(r => r.Name == name)
                ?? throw new WdbRecordNotFoundException(name);
        }

        /// <summary>
        /// Gets the records.
        /// </summary>
        /// <param name="wdbReader">The wdb reader.</param>
        /// <param name="options">The options.</param>
        /// <returns><![CDATA[List<WdbRecord>]]></returns>
        public List<WdbRecord>? GetRecords(BinaryReader wdbReader, WdbStructOptions options)
        {
            List<WdbRecord> records = new();

            bool checkPosition =
                options.RecordLengthRecordName is string recordLengthName
                && !string.IsNullOrWhiteSpace(recordLengthName);

            long position = wdbReader.BaseStream.Position;
            long? endPosition = null;

            try
            {
                foreach (WdbRecord record in GetRecords(wdbReader, options.RecordOptions))
                {
                    position = wdbReader.BaseStream.Position;
                    CheckReaderPosition(checkPosition, record, position, ref endPosition, options);
                    records.Add(record);
                }
                CheckReaderPosition(position, endPosition, wdbReader);
            }
            catch (EndOfStreamException ex)
            {
                Logger.LogWarning(
                    "Caught Exception: '{Exception}', please check given options '{Options}'",
                    ex.Message,
                    options
                );
            }
            if (records.Count == options.RecordOptions.Count)
            {
                return records;
            }
            return null;
        }

        /// <inheritdoc/>
        public float GetRecordValueFloatNotNull(IEnumerable<WdbRecord> records, string name)
        {
            return GetRecordValueFloatNotNull(GetRecord(records, name));
        }

        /// <inheritdoc/>
        public float GetRecordValueFloatNotNull(WdbRecord record)
        {
            return record.GetFloatValue() ?? throw new WdbRecordValueNullException(record.Name);
        }

        /// <inheritdoc/>
        public uint GetRecordValueIntNotNull(IEnumerable<WdbRecord> records, string name)
        {
            return GetRecordValueIntNotNull(GetRecord(records, name));
        }

        /// <inheritdoc/>
        public uint GetRecordValueIntNotNull(WdbRecord record)
        {
            return record.GetIntValue() ?? throw new WdbRecordValueNullException(record.Name);
        }

        /// <inheritdoc/>
        public string GetRecordValueStringNotNull(IEnumerable<WdbRecord> records, string name)
        {
            return GetRecordValueStringNotNull(GetRecord(records, name));
        }

        /// <inheritdoc/>
        public string GetRecordValueStringNotNull(WdbRecord record)
        {
            return record.GetStringValue() ?? throw new WdbRecordValueNullException(record.Name);
        }

        /// <summary>
        /// Check reader position.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="endPosition">The end position.</param>
        /// <param name="wdbReader">The wdb reader.</param>
        private void CheckReaderPosition(long position, long? endPosition, BinaryReader wdbReader)
        {
            if (endPosition is null)
            {
                return;
            }
            if (position < endPosition)
            {
                Logger.LogWarning(
                    "struct record size not fully read. there are still '{Count}' bytes remaining: {Bytes}",
                    endPosition - position,
                    string.Join(", ", wdbReader.ReadBytes((int)(endPosition - position)))
                );
            }
            else if (position > endPosition)
            {
                Logger.LogWarning(
                    "exceeding struct recordsize. current final position '{Position}' "
                        + "is larger than struct end position '{EndPosition}'",
                    position,
                    endPosition
                );
            }
        }

        /// <summary>
        /// Check reader position.
        /// </summary>
        /// <param name="checkPosition">If true, check position.</param>
        /// <param name="record">The record.</param>
        /// <param name="position">The position.</param>
        /// <param name="endPosition">The end position.</param>
        /// <param name="options">The options.</param>
        private void CheckReaderPosition(
            bool checkPosition,
            WdbRecord record,
            long position,
            ref long? endPosition,
            WdbStructOptions options
        )
        {
            if (checkPosition && record.Name == options.RecordLengthRecordName)
            {
                endPosition = position + GetRecordValueIntNotNull(record);
            }
            if (endPosition is not null && position > endPosition)
            {
                Logger.LogWarning(
                    "exceeding struct recordsize. current position '{Position}' "
                        + "is larger than struct end position '{EndPosition}'",
                    position,
                    endPosition
                );
            }
        }

        /// <summary>
        /// Gets the records.
        /// </summary>
        /// <param name="wdbReader">The wdb reader.</param>
        /// <param name="options">The options.</param>
        /// <returns><![CDATA[IEnumerable<WdbRecord>]]></returns>
        private IEnumerable<WdbRecord> GetRecords(
            BinaryReader wdbReader,
            List<WdbRecordOptions> options
        )
        {
            List<WdbRecord> records = new();
            foreach (WdbRecordOptions option in options)
            {
                if (wdbReader.BaseStream.Position == wdbReader.BaseStream.Length)
                {
                    Logger.LogInformation(
                        "End of stream reached at position {Position}. Returning",
                        wdbReader.BaseStream.Position
                    );
                    yield break;
                }

                // counted records implementation is untested, as it appears it isn't needed for
                // vanilla .wdb files. Leaving it in in case someone wants to use it for later expansions
                uint recordCount = 1;
                if (
                    option.CountSettingRecordName is string countSettingRecordName
                    && !string.IsNullOrWhiteSpace(countSettingRecordName)
                    && records.Find(r => r.Name == countSettingRecordName)
                        is WdbRecord countSettingRecord
                )
                {
                    recordCount = GetRecordValueIntNotNull(countSettingRecord);
                }

                foreach (WdbRecord record in GetRecords(wdbReader, recordCount, option))
                {
                    records.Add(record);
                    yield return record;
                }
            }
            yield break;
        }

        /// <summary>
        /// Gets the records.
        /// </summary>
        /// <param name="wdbReader">The wdb reader.</param>
        /// <param name="recordCount">The record count.</param>
        /// <param name="option">The option.</param>
        /// <returns><![CDATA[IEnumerable<WdbRecord>]]></returns>
        private IEnumerable<WdbRecord> GetRecords(
            BinaryReader wdbReader,
            uint recordCount,
            WdbRecordOptions option
        )
        {
            if (recordCount == 0)
            {
                yield break;
            }
            for (int i = 1; i <= recordCount; i++)
            {
                if (wdbReader.BaseStream.Position != wdbReader.BaseStream.Length)
                {
                    if (recordCount > 1)
                    {
                        option.Name = $"{option.Name}{i}";
                    }
                    yield return wdbReader.ReadWdbRecord(option);
                }
                else
                {
                    Logger.LogInformation(
                        "End of stream reached at position {Position}. Returning",
                        wdbReader.BaseStream.Position
                    );
                    yield break;
                }
            }
        }

        #endregion Methods
    }
}
