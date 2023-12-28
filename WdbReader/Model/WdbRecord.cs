using WdbReader.Model.Exceptions;

namespace WdbReader.Model
{
    /// <summary>
    /// The wdb record.
    /// </summary>
    public class WdbRecord
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WdbRecord"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="dataType">The data type.</param>
        public WdbRecord(string name, object? value, WdbRecordDataType dataType)
        {
            Name = name;
            Value = value;
            DataType = dataType;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or Sets the data type.
        /// </summary>
        public WdbRecordDataType DataType { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or Sets the value.
        /// </summary>
        public object? Value { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the bit mask value.
        /// </summary>
        /// <exception cref="WdbRecordValueTypeException"></exception>
        /// <returns>A byte[]? .</returns>
        public byte[]? GetBitMaskValue()
        {
            if (DataType != WdbRecordDataType.BitMaskType)
            {
                throw new WdbRecordValueTypeException(typeof(byte), DataType);
            }
            return Value as byte[];
        }

        /// <summary>
        /// Get the float value.
        /// </summary>
        /// <exception cref="WdbRecordValueTypeException"></exception>
        /// <returns>A float? .</returns>
        public float? GetFloatValue()
        {
            if (DataType != WdbRecordDataType.FloatType)
            {
                throw new WdbRecordValueTypeException(typeof(float), DataType);
            }
            if (Value is null)
            {
                return null;
            }
            return (float)Value;
        }

        /// <summary>
        /// Gets the integer value.
        /// </summary>
        /// <exception cref="WdbRecordValueTypeException"></exception>
        /// <returns>An int? .</returns>
        public uint? GetIntValue()
        {
            if (DataType != WdbRecordDataType.IntegerType)
            {
                throw new WdbRecordValueTypeException(typeof(uint), DataType);
            }
            if (Value is null)
            {
                return null;
            }
            return (uint)Value;
        }

        /// <summary>
        /// Gets the string value.
        /// </summary>
        /// <exception cref="WdbRecordValueTypeException"></exception>
        /// <returns>A string? .</returns>
        public string? GetStringValue()
        {
            if (
                DataType
                is not WdbRecordDataType.StringType
                    and not WdbRecordDataType.StringNullType
            )
            {
                throw new WdbRecordValueTypeException(typeof(string), DataType);
            }
            return Value as string;
        }

        #endregion Methods
    }
}
