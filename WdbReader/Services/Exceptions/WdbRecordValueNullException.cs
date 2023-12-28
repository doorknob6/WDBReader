namespace WdbReader.Services.Exceptions
{
    /// <summary>
    /// The wdb record value null exception.
    /// </summary>
    public class WdbRecordValueNullException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbRecordValueNullException"/> class.
        /// </summary>
        public WdbRecordValueNullException()
            : base("The requested wdb records value is null.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbRecordValueNullException"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public WdbRecordValueNullException(string? name)
            : base($"The requested wdb record '{name}' value is null") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbRecordValueNullException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public WdbRecordValueNullException(string? message, Exception? innerException)
            : base(message, innerException) { }

        #endregion Constructors
    }
}
