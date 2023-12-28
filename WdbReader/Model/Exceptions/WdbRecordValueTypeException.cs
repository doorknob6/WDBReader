namespace WdbReader.Model.Exceptions
{
    /// <summary>
    /// The wdb record type exception.
    /// </summary>
    public class WdbRecordValueTypeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WdbRecordValueTypeException"/> class.
        /// </summary>
        public WdbRecordValueTypeException()
            : this("The requested value type does not match this wdb records value type.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbRecordValueTypeException"/> class.
        /// </summary>
        /// <param name="requestedType">The requested type.</param>
        /// <param name="valueType">The value type.</param>
        public WdbRecordValueTypeException(Type requestedType, WdbRecordDataType valueType)
            : this(
                $"The requested value type '{requestedType}' "
                    + $"does not match this wdb records value type '{valueType}'."
            )
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbRecordValueTypeException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public WdbRecordValueTypeException(string? message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbRecordValueTypeException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public WdbRecordValueTypeException(string? message, Exception? innerException)
            : base(message, innerException) { }
    }
}
