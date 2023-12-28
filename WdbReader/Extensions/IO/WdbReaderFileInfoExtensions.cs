namespace WdbReader.Extensions.IO
{
    /// <summary>
    /// The wdb reader file info extensions.
    /// </summary>
    public static class WdbReaderFileInfoExtensions
    {
        #region Methods

        /// <summary>
        /// Opens a binary file, reads the contents of the file into a byte array, and then closes
        /// the file.
        /// </summary>
        /// <param name="fileInfo">The file info.</param>
        /// <returns>An array of bytes</returns>
        public static byte[] ReadAllBytes(this FileInfo fileInfo)
        {
            return File.ReadAllBytes(fileInfo.FullName);
        }

        /// <summary>
        /// Converts to binary reader.
        /// </summary>
        /// <param name="fileInfo">The file info.</param>
        /// <returns>A BinaryReader.</returns>
        public static BinaryReader ToBinaryReader(this FileInfo fileInfo)
        {
            return new(fileInfo.ToByteMemoryStream());
        }

        /// <summary>
        /// Converts to byte memory stream.
        /// </summary>
        /// <param name="fileInfo">The file info.</param>
        /// <returns>A MemoryStream.</returns>
        public static MemoryStream ToByteMemoryStream(this FileInfo fileInfo)
        {
            return new(fileInfo.ReadAllBytes());
        }

        #endregion Methods
    }
}
