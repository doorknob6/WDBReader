namespace WdbReader.Model
{
    /// <summary>
    /// The wdb struct.
    /// </summary>
    public class WdbStruct
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbStruct"/> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="identifierType">The identifier type.</param>
        /// <param name="records">The records.</param>
        public WdbStruct(
            object identifier,
            WdbRecordDataType identifierType,
            List<WdbRecord> records
        )
        {
            Identifier = identifier;
            IdentifierType = identifierType;
            Records = records;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public object Identifier { get; }

        /// <summary>
        /// Gets the identifier type.
        /// </summary>
        public WdbRecordDataType IdentifierType { get; }

        /// <summary>
        /// Gets the records.
        /// </summary>
        public List<WdbRecord> Records { get; }

        #endregion Properties
    }
}
