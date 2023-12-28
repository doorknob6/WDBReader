namespace WdbReader.Services.Exceptions
{
    /// <summary>
    /// The multiple files found exception.
    /// </summary>
    public class MultipleFilesFoundException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleFilesFoundException"/> class.
        /// </summary>
        public MultipleFilesFoundException()
            : this("Multiple files found where only one was expected.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleFilesFoundException"/> class.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <param name="fileName">The file name.</param>
        /// <param name="innerException">The inner exception.</param>
        public MultipleFilesFoundException(
            DirectoryInfo directory,
            string fileName,
            Exception? innerException
        )
            : this(
                $"Multiple files with name '{fileName}' found in directory "
                    + $"'{directory.Name}', where only one was expected.",
                innerException
            )
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleFilesFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public MultipleFilesFoundException(string? message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleFilesFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public MultipleFilesFoundException(string? message, Exception? innerException)
            : base(message, innerException) { }

        #endregion Constructors
    }
}
