namespace WdbReader.Services.Exceptions
{
    /// <summary>
    /// The wdb records not found exception.
    /// </summary>
    public class WdbRecordsNotFoundException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbRecordsNotFoundException"/> class.
        /// </summary>
        public WdbRecordsNotFoundException()
            : base("No Wdb Records where found.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbRecordsNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public WdbRecordsNotFoundException(string? message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbRecordsNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public WdbRecordsNotFoundException(string? message, Exception? innerException)
            : base(message, innerException) { }

        #endregion Constructors
    }
}
