namespace WdbReader.Model
{
    /// <summary>
    /// The record data type.
    /// </summary>
    public enum WdbRecordDataType
    {
        /// <summary>
        /// The integer record type.
        /// </summary>
        IntegerType,

        /// <summary>
        /// The float record type.
        /// </summary>
        FloatType,

        /// <summary>
        /// The string record type.
        /// </summary>
        StringType,

        /// <summary>
        /// The variable length or empty string record type.
        /// </summary>
        StringNullType,

        /// <summary>
        /// The bitmask record type.
        /// </summary>
        BitMaskType
    }
}
