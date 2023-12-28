using WdbReader.Model;
using WdbReader.Options;

namespace WdbReader.Services.Contracts
{
    /// <summary>
    /// The wdb record service interface.
    /// </summary>
    public interface IWdbRecordService
    {
        #region Methods

        /// <summary>
        /// Get the record.
        /// </summary>
        /// <param name="records">The records.</param>
        /// <param name="name">The name.</param>
        /// <returns>A WdbRecord.</returns>
        WdbRecord GetRecord(IEnumerable<WdbRecord> records, string name);

        /// <summary>
        /// Gets the records.
        /// </summary>
        /// <param name="wdbReader">The wdb reader.</param>
        /// <param name="options">The options.</param>
        /// <returns><![CDATA[List<WdbRecord?>]]></returns>
        List<WdbRecord>? GetRecords(BinaryReader wdbReader, WdbStructOptions options);

        /// <summary>
        /// Get the record value float not null.
        /// </summary>
        /// <param name="records">The records.</param>
        /// <param name="name">The name.</param>
        /// <returns>A float.</returns>
        float GetRecordValueFloatNotNull(IEnumerable<WdbRecord> records, string name);

        /// <summary>
        /// Get the record value float not null.
        /// </summary>
        /// <param name="record">The record.</param>
        /// <returns>An float.</returns>
        float GetRecordValueFloatNotNull(WdbRecord record);

        /// <summary>
        /// Get the record value integer not null.
        /// </summary>
        /// <param name="records">The records.</param>
        /// <param name="name">The name.</param>
        /// <returns>An int.</returns>
        uint GetRecordValueIntNotNull(IEnumerable<WdbRecord> records, string name);

        /// <summary>
        /// Get the record value integer not null.
        /// </summary>
        /// <param name="record">The record.</param>
        /// <returns>An int.</returns>
        uint GetRecordValueIntNotNull(WdbRecord record);

        /// <summary>
        /// Get the record value string not null.
        /// </summary>
        /// <param name="records">The records.</param>
        /// <param name="name">The name.</param>
        /// <returns>A string.</returns>
        string GetRecordValueStringNotNull(IEnumerable<WdbRecord> records, string name);

        /// <summary>
        /// Get the record value string not null.
        /// </summary>
        /// <param name="record">The record.</param>
        /// <returns>A string.</returns>
        string GetRecordValueStringNotNull(WdbRecord record);

        #endregion Methods
    }
}
