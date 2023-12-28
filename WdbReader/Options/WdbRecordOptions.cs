using WdbReader.Model;

namespace WdbReader.Options
{
    /// <summary>
    /// The record options.
    /// </summary>
    public class WdbRecordOptions
    {
        #region Properties

        /// <summary>
        /// Gets or Sets the count setting record name.
        /// </summary>
        /// <remarks>
        /// This property gives the opportunity to assign another record to signify the amount of
        /// times this record appears consecutively.
        /// </remarks>
        public string? CountSettingRecordName { get; set; }

        /// <summary>
        /// Gets or Sets the data type.
        /// </summary>
        public required WdbRecordDataType DataType { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether is reversed.
        /// </summary>
        public required bool IsReversed { get; set; }

        /// <summary>
        /// Gets or Sets the length.
        /// </summary>
        public required int Length { get; set; } = 4;

        /// <summary>
        /// Gets or Sets the name.
        /// </summary>
        public required string Name { get; set; }

        #endregion Properties
    }
}
