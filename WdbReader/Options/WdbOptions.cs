namespace WdbReader.Options
{
    /// <summary>
    /// The wdb options.
    /// </summary>
    public class WdbOptions : WdbStructOptions
    {
        #region Properties

        /// <summary>
        /// Gets or Sets the file name.
        /// </summary>
        public required string FileName { get; set; }

        /// <summary>
        /// Gets or Sets the header options.
        /// </summary>
        public required WdbHeaderOptions HeaderOptions { get; set; }

        #endregion Properties
    }
}
