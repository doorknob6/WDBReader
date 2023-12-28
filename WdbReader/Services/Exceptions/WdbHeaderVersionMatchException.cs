namespace WdbReader.Services.Exceptions
{
    /// <summary>
    /// The wdb header version match exception.
    /// </summary>
    public class WdbHeaderVersionMatchException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbHeaderVersionMatchException"/> class.
        /// </summary>
        public WdbHeaderVersionMatchException()
            : base("The Wdb file header version does not match the given one.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbHeaderVersionMatchException"/> class.
        /// </summary>
        /// <param name="foundVersion">The found version.</param>
        /// <param name="givenVersion">The given version.</param>
        public WdbHeaderVersionMatchException(uint foundVersion, uint givenVersion)
            : this(
                $"The Wdb file header version '{foundVersion}' "
                    + $"does not match the given one '{givenVersion}'."
            )
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbHeaderVersionMatchException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public WdbHeaderVersionMatchException(string? message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbHeaderVersionMatchException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public WdbHeaderVersionMatchException(string? message, Exception? innerException)
            : base(message, innerException) { }

        #endregion Constructors
    }
}
