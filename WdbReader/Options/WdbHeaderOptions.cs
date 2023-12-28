namespace WdbReader.Options
{
    /// <summary>
    /// The header options.
    /// </summary>
    public class WdbHeaderOptions : WdbStructOptions
    {
        #region Properties

        /// <summary>
        /// Gets or Sets the signature.
        /// </summary>
        public required string Signature { get; set; }

        /// <summary>
        /// Gets or Sets the version.
        /// </summary>
        public required uint Version { get; set; }

        #endregion Properties
    }
}
