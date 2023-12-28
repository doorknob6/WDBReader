namespace WdbReader.Services.Exceptions
{
    /// <summary>
    /// The wdb header signature match exception.
    /// </summary>
    public class WdbHeaderSignatureMatchException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbHeaderSignatureMatchException"/> class.
        /// </summary>
        public WdbHeaderSignatureMatchException()
            : base("The Wdb file header signature does not match the given one.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbHeaderSignatureMatchException"/> class.
        /// </summary>
        /// <param name="foundSignature">The found signature.</param>
        /// <param name="givenSignature">The given signature.</param>
        public WdbHeaderSignatureMatchException(string foundSignature, string givenSignature)
            : base(
                $"The Wdb file header signature '{foundSignature}' "
                    + $"does not match the given one '{givenSignature}'."
            )
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbHeaderSignatureMatchException"/> class.
        /// </summary>
        /// <param name="signature">The signature.</param>
        public WdbHeaderSignatureMatchException(string? signature)
            : base($"The Wdb file header signature does not match the given one '{signature}'.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbHeaderSignatureMatchException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public WdbHeaderSignatureMatchException(string? message, Exception? innerException)
            : base(message, innerException) { }

        #endregion Constructors
    }
}
