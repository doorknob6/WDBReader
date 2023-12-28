namespace WdbReader.Services.Exceptions
{
    /// <summary>
    /// The wdb record not found exception.
    /// </summary>
    public class WdbRecordNotFoundException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbRecordNotFoundException"/> class.
        /// </summary>
        public WdbRecordNotFoundException()
            : base("A record was requested by name and not found.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbRecordNotFoundException"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public WdbRecordNotFoundException(string? name)
            : base($"A record was requested by name '{name}' and not found.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbRecordNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public WdbRecordNotFoundException(string? message, Exception? innerException)
            : base(message, innerException) { }

        #endregion Constructors
    }
}
