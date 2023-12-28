using System.Text;
using WdbReader.Model;
using WdbReader.Options;

namespace WdbReader.Extensions.Text
{
    /// <summary>
    /// The binary reader extensions.
    /// </summary>
    public static class WdbReaderBinaryReaderExtensions
    {
        #region Methods

        /// <summary>
        /// Reads the string.
        /// </summary>
        /// <param name="br">The br.</param>
        /// <param name="count">The count.</param>
        /// <returns>A string.</returns>
        public static string ReadString(this BinaryReader br, int count)
        {
            byte[] stringArray = br.ReadBytes(count);
            return Encoding.UTF8.GetString(stringArray);
        }

        /// <summary>
        /// Reads the string null.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>A string.</returns>
        public static string ReadStringNull(this BinaryReader reader)
        {
            byte num;
            List<byte> temp = new();

            while ((num = reader.ReadByte()) != 0)
            {
                temp.Add(num);
            }

            return Encoding.UTF8.GetString(temp.ToArray());
        }

        /// <summary>
        /// Reads the wdb record.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="options">The options.</param>
        /// <returns>A WdbRecord.</returns>
        public static WdbRecord ReadWdbRecord(this BinaryReader reader, WdbRecordOptions options)
        {
            return new(
                options.Name,
                options.DataType switch
                {
                    WdbRecordDataType.IntegerType => CheckUintValue(reader.ReadUInt32()),
                    WdbRecordDataType.FloatType => reader.ReadSingle(),
                    WdbRecordDataType.StringType
                        => options.IsReversed
                            ? string.Join("", reader.ReadString(options.Length).Reverse())
                            : reader.ReadString(options.Length),
                    WdbRecordDataType.StringNullType
                        => options.IsReversed
                            ? string.Join("", reader.ReadStringNull().Reverse())
                            : reader.ReadStringNull(),
                    WdbRecordDataType.BitMaskType => reader.ReadBytes(options.Length),
                    _ => null
                },
                options.DataType == WdbRecordDataType.StringNullType
                    ? WdbRecordDataType.StringType
                    : options.DataType
            );
        }

        /// <summary>
        /// Check uint value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>An uint.</returns>
        private static uint CheckUintValue(uint value)
        {
            if (value == uint.MaxValue)
            {
                value = 0;
            }
            return value;
        }

        #endregion Methods
    }
}
