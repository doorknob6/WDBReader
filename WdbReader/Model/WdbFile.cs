namespace WdbReader.Model
{
    /// <summary>
    /// The wdb file.
    /// </summary>
    public class WdbFile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbFile"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="signature">The signature.</param>
        /// <param name="locale">The locale.</param>
        /// <param name="version">The version.</param>
        /// <param name="recordSize">The record size.</param>
        /// <param name="recordVersion">The record version.</param>
        public WdbFile(
            string name,
            string signature,
            string locale,
            uint version,
            uint recordSize,
            uint recordVersion
        )
        {
            Name = name;
            Signature = signature;
            Locale = locale;
            Version = version;
            RecordSize = recordSize;
            RecordVersion = recordVersion;
            Items = new();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the items.
        /// </summary>
        public List<WdbStruct> Items { get; }

        /// <summary>
        /// Gets the locale.
        /// </summary>
        public string Locale { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the record size.
        /// </summary>
        public uint RecordSize { get; }

        /// <summary>
        /// Gets the record version.
        /// </summary>
        public uint RecordVersion { get; }

        /// <summary>
        /// Gets the signature.
        /// </summary>
        public string Signature { get; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        public uint Version { get; }

        #endregion Properties
    }
}
