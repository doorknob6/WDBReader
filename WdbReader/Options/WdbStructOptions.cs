namespace WdbReader.Options
{
    /// <summary>
    /// The struct options.
    /// </summary>
    public abstract class WdbStructOptions
    {
        #region Properties

        /// <summary>
        /// Gets or Sets the record length record name.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This property is necessary for wdb data structs, which usually have a variable length
        /// due to the variable length strings they contain. Usually the second record in a struct
        /// with an integer value contains the record struct length. In the example settings these
        /// records have been called "RecordLength".
        /// </para>
        /// <para>
        /// Setting this setting to the name of the record containing the struct length allows the
        /// record service to account for the variable struct record lengths.
        /// </para>
        /// </remarks>
        public string? RecordLengthRecordName { get; set; }

        /// <summary>
        /// Gets or Sets the record options.
        /// </summary>
        public required List<WdbRecordOptions> RecordOptions { get; set; }

        #endregion Properties
    }
}
