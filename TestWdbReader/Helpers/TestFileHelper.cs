using WdbReader.Extensions.IO;
using WdbReader.Model;
using WdbReader.Options;

namespace TestWdbReader.Helpers
{
    /// <summary>
    /// The test file helper.
    /// </summary>
    internal class TestFileHelper
    {
        #region Fields

        /// <summary>
        /// The game object cache empty file.
        /// </summary>
        private static readonly FileInfo _gameObjectCacheEmptyFile =
            new("resources/wdb_empty/gameobjectcache.wdb");

        /// <summary>
        /// The game object cache empty reader.
        /// </summary>
        private static readonly BinaryReader _gameObjectCacheEmptyReader =
            _gameObjectCacheEmptyFile.ToBinaryReader();

        /// <summary>
        /// The game object cache file.
        /// </summary>
        private static readonly FileInfo _gameObjectCacheFile =
            new("resources/wdb/gameobjectcache.wdb");

        /// <summary>
        /// The game object cache reader.
        /// </summary>
        private static readonly BinaryReader _gameObjectCacheReader =
            _gameObjectCacheFile.ToBinaryReader();

        /// <summary>
        /// The game object cache version mismatch options.
        /// </summary>
        private static readonly WdbOptions _gameObjectCacheVersionMismatchOptions =
            new()
            {
                FileName = "gameobjectcache.wdb",
                HeaderOptions = new()
                {
                    Signature = "WGOB",
                    Version = 1000u,
                    RecordLengthRecordName = null,
                    RecordOptions = new()
                    {
                        new()
                        {
                            DataType = WdbRecordDataType.StringType,
                            IsReversed = true,
                            Length = 4,
                            Name = "Signature"
                        },
                        new()
                        {
                            DataType = WdbRecordDataType.IntegerType,
                            IsReversed = false,
                            Length = 4,
                            Name = "Version"
                        },
                        new()
                        {
                            DataType = WdbRecordDataType.StringType,
                            IsReversed = true,
                            Length = 4,
                            Name = "Locale"
                        },
                        new()
                        {
                            DataType = WdbRecordDataType.IntegerType,
                            IsReversed = false,
                            Length = 4,
                            Name = "RecordSize"
                        },
                        new()
                        {
                            DataType = WdbRecordDataType.IntegerType,
                            IsReversed = false,
                            Length = 4,
                            Name = "RecordVersion"
                        }
                    }
                },
                RecordLengthRecordName = "RecordLength",
                RecordOptions = new() { }
            };

        /// <summary>
        /// The item cache empty file.
        /// </summary>
        private static readonly FileInfo _itemCacheEmptyFile =
            new("resources/wdb_empty/itemcache.wdb");

        /// <summary>
        /// The item cache empty reader.
        /// </summary>
        private static readonly BinaryReader _itemCacheEmptyReader =
            _itemCacheEmptyFile.ToBinaryReader();

        /// <summary>
        /// The item cache file.
        /// </summary>
        private static readonly FileInfo _itemCacheFile = new("resources/wdb/itemcache.wdb");

        /// <summary>
        /// The item cache reader.
        /// </summary>
        private static readonly BinaryReader _itemCacheReader = _itemCacheFile.ToBinaryReader();

        /// <summary>
        /// The item cache version mismatch options.
        /// </summary>
        private static readonly WdbOptions _itemCacheVersionMismatchOptions =
            new()
            {
                FileName = "itemcache.wdb",
                HeaderOptions = new()
                {
                    Signature = "WIDB",
                    Version = 1000u,
                    RecordOptions = new()
                    {
                        new()
                        {
                            DataType = WdbRecordDataType.StringType,
                            IsReversed = true,
                            Length = 4,
                            Name = "Signature"
                        },
                        new()
                        {
                            Length = 4,
                            Name = "Version",
                            DataType = WdbRecordDataType.IntegerType,
                            IsReversed = false
                        },
                        new()
                        {
                            DataType = WdbRecordDataType.StringType,
                            IsReversed = true,
                            Length = 4,
                            Name = "Locale"
                        },
                        new()
                        {
                            Length = 4,
                            Name = "RecordSize",
                            DataType = WdbRecordDataType.IntegerType,
                            IsReversed = false
                        },
                        new()
                        {
                            Length = 4,
                            Name = "RecordVersion",
                            DataType = WdbRecordDataType.IntegerType,
                            IsReversed = false
                        }
                    }
                },
                RecordLengthRecordName = "RecordLength",
                RecordOptions = new() { }
            };

        /// <summary>
        /// The wdb directory.
        /// </summary>
        private static readonly DirectoryInfo _wdbDirectory = new("resources/wdb");

        /// <summary>
        /// The wdb double files directory.
        /// </summary>
        private static readonly DirectoryInfo _wdbDoubleFilesDirectory =
            new("resources/wdb_double");

        /// <summary>
        /// The wdb no directory.
        /// </summary>
        private static readonly DirectoryInfo _wdbNoDirectory = new("resources/wdb_");

        /// <summary>
        /// The wdb no files directory.
        /// </summary>
        private static readonly DirectoryInfo _wdbNoFilesDirectory = new("resources/wdb_nofiles");

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the initial string data.
        /// </summary>
        /// <remarks>
        /// Contains arrays containing the <see cref="BinaryReader"/> for the file to test on, the
        /// <see cref="int"/> position of the initial string and the <see cref="string"/> value of
        /// the initial string contained in the file.
        /// </remarks>
        public static IEnumerable<object[]> InitialStringData =>
            new[]
            {
                new object[] { _gameObjectCacheReader, 0, "BOGW" },
                new object[] { _itemCacheReader, 0, "BDIW" }
            };

        /// <summary>
        /// Gets the file length data.
        /// </summary>
        /// <remarks>
        /// Contains arrays containing the <see cref="FileInfo"/> for the file to test on and the
        /// <see cref="int"/> length of the file in bytes.
        /// </remarks>
        public static IEnumerable<object[]> LengthData =>
            new[]
            {
                new object[] { _gameObjectCacheFile, 21866 },
                new object[] { _itemCacheFile, 502702 }
            };

        /// <summary>
        /// Gets the file string null data.
        /// </summary>
        /// <remarks>
        /// Contains arrays containing the <see cref="BinaryReader"/> for the file to test on, the
        /// <see cref="int"/> position of the string to find and the <see cref="string"/> value of
        /// the string contained in the file.
        /// </remarks>
        public static IEnumerable<object[]> StringNullData =>
            new[]
            {
                new object[] { _gameObjectCacheReader, 36, "TEST Ship" },
                new object[] { _gameObjectCacheReader, 21367, "Dwarven Brazier" },
                new object[] { _itemCacheReader, 36, "Apprentice's Shirt" },
                new object[] { _itemCacheReader, 502165, "Zum'rah's Vexing Cane" }
            };

        /// <summary>
        /// Gets the wdb directory.
        /// </summary>
        /// <remarks>This directory contains normal .wdb files for testing.</remarks>
        public static DirectoryInfo WdbDirectory => _wdbDirectory;

        /// <summary>
        /// Gets the wdb directory not found data.
        /// </summary>
        public static IEnumerable<object[]> WdbDirectoryNotFoundData =>
            new[]
            {
                new object[] { _wdbNoDirectory, OptionsHelper.GameObjectCacheOptions },
                new object[] { _wdbNoDirectory, OptionsHelper.ItemCacheOptions },
            };

        /// <summary>
        /// Gets the wdb file data.
        /// </summary>
        /// <remarks>
        /// Contains arrays containing the <see cref="DirectoryInfo"/> where the file to test on is
        /// present once, the <see cref="WdbOptions"/> for the wdb file to read, the <see
        /// cref="WdbFile"/> expected value and the <see cref="int"/> amount of items record structs
        /// expected in the wdb.
        /// </remarks>
        public static IEnumerable<object[]> WdbFileData =>
            new[]
            {
                new object[]
                {
                    _wdbDirectory,
                    OptionsHelper.GameObjectCacheOptions,
                    new WdbFile("gameobjectcache.wdb", "WGOB", "enUS", 5875u, 124u, 1u),
                    122
                },
                new object[]
                {
                    _wdbDirectory,
                    OptionsHelper.ItemCacheOptions,
                    new WdbFile("itemcache.wdb", "WIDB", "enUS", 5875u, 468u, 5u),
                    933
                },
            };

        /// <summary>
        /// Gets the wdb file double data.
        /// </summary>
        /// <remarks>
        /// Contains arrays containing the <see cref="DirectoryInfo"/> where the file to test on is
        /// present twice and the <see cref="WdbOptions"/> for the wdb file to read.
        /// </remarks>
        public static IEnumerable<object[]> WdbFileDoubleData =>
            new[]
            {
                new object[] { _wdbDoubleFilesDirectory, OptionsHelper.GameObjectCacheOptions },
                new object[] { _wdbDoubleFilesDirectory, OptionsHelper.ItemCacheOptions },
            };

        /// <summary>
        /// Gets the wdb file not found data.
        /// </summary>
        /// <remarks>
        /// Contains arrays containing the <see cref="DirectoryInfo"/> where the file to test on is
        /// not present and the <see cref="WdbOptions"/> for the wdb file to read.
        /// </remarks>
        public static IEnumerable<object[]> WdbFileNotFoundData =>
            new[]
            {
                new object[] { _wdbNoFilesDirectory, OptionsHelper.GameObjectCacheOptions },
                new object[] { _wdbNoFilesDirectory, OptionsHelper.ItemCacheOptions },
            };

        /// <summary>
        /// Gets the wdb header data.
        /// </summary>
        /// <remarks>
        /// Contains arrays containing the <see cref="BinaryReader"/> for the file to test on, the
        /// <see cref="int"/> position of the header struct to find, the <see cref="WdbOptions"/>
        /// for the wdb file and the <see cref="WdbFile"/> expected value.
        /// </remarks>
        public static IEnumerable<object[]> WdbHeaderData =>
            new[]
            {
                new object[]
                {
                    _gameObjectCacheReader,
                    0,
                    OptionsHelper.GameObjectCacheOptions,
                    new WdbFile("gameobjectcache.wdb", "WGOB", "enUS", 5875u, 124u, 1u)
                },
                new object[]
                {
                    _itemCacheReader,
                    0,
                    OptionsHelper.ItemCacheOptions,
                    new WdbFile("itemcache.wdb", "WIDB", "enUS", 5875u, 468u, 5u)
                },
            };

        /// <summary>
        /// Gets the wdb header empty data.
        /// </summary>
        /// <remarks>
        /// Contains arrays containing the <see cref="BinaryReader"/> for the empty file to test on,
        /// the <see cref="int"/> position of the header struct to find and the <see
        /// cref="WdbOptions"/> for the wdb file.
        /// </remarks>
        public static IEnumerable<object[]> WdbHeaderEmptyData =>
            new[]
            {
                new object[]
                {
                    _gameObjectCacheEmptyReader,
                    0,
                    OptionsHelper.GameObjectCacheOptions
                },
                new object[] { _itemCacheEmptyReader, 0, OptionsHelper.ItemCacheOptions },
            };

        /// <summary>
        /// Gets the wdb header signature mismatch data.
        /// </summary>
        /// <remarks>
        /// Contains arrays containing the <see cref="BinaryReader"/> for the file to test on, the
        /// <see cref="int"/> position of the header struct to find and the <see cref="WdbOptions"/>
        /// for a different wdb file.
        /// </remarks>
        public static IEnumerable<object[]> WdbHeaderSignatureMismatchData =>
            new[]
            {
                new object[] { _itemCacheReader, 0, OptionsHelper.GameObjectCacheOptions },
                new object[] { _gameObjectCacheReader, 0, OptionsHelper.ItemCacheOptions },
            };

        /// <summary>
        /// Gets the wdb header version mismatch data.
        /// </summary>
        /// <remarks>
        /// Contains arrays containing the <see cref="BinaryReader"/> for the file to test on, the
        /// <see cref="int"/> position of the header struct to find and the <see cref="WdbOptions"/>
        /// for a wdb file for a different version.
        /// </remarks>
        public static IEnumerable<object[]> WdbHeaderVersionMismatchData =>
            new[]
            {
                new object[] { _gameObjectCacheReader, 0, _gameObjectCacheVersionMismatchOptions },
                new object[] { _itemCacheReader, 0, _itemCacheVersionMismatchOptions },
            };

        /// <summary>
        /// Gets the wdb record data.
        /// </summary>
        /// <remarks>
        /// Contains arrays containing the <see cref="BinaryReader"/> for the file to test on, the
        /// <see cref="int"/> position of the record to find, the <see cref="WdbRecordOptions"/> for
        /// the record and the <see cref="WdbRecord"/> expected value of the record.
        /// </remarks>
        public static IEnumerable<object[]> WdbRecordData =>
            new[]
            {
                new object[]
                {
                    _gameObjectCacheReader,
                    0,
                    new WdbRecordOptions()
                    {
                        Name = "Signature",
                        DataType = WdbRecordDataType.StringType,
                        IsReversed = true,
                        Length = 4
                    },
                    new WdbRecord("Signature", "WGOB", WdbRecordDataType.StringType)
                },
                new object[]
                {
                    _gameObjectCacheReader,
                    0,
                    new WdbRecordOptions()
                    {
                        Name = "Signature",
                        DataType = WdbRecordDataType.StringType,
                        IsReversed = false,
                        Length = 4
                    },
                    new WdbRecord("Signature", "BOGW", WdbRecordDataType.StringType)
                },
                new object[]
                {
                    _gameObjectCacheReader,
                    20,
                    new WdbRecordOptions()
                    {
                        Name = "Identifier",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4
                    },
                    new WdbRecord("Identifier", 20808u, WdbRecordDataType.IntegerType)
                },
                new object[]
                {
                    _gameObjectCacheReader,
                    36,
                    new WdbRecordOptions()
                    {
                        Name = "NameOne",
                        DataType = WdbRecordDataType.StringNullType,
                        IsReversed = false,
                        Length = 4
                    },
                    new WdbRecord("NameOne", "TEST Ship", WdbRecordDataType.StringType)
                },
                new object[]
                {
                    _gameObjectCacheReader,
                    36,
                    new WdbRecordOptions()
                    {
                        Name = "NameOne",
                        DataType = WdbRecordDataType.StringNullType,
                        IsReversed = true,
                        Length = 4
                    },
                    new WdbRecord("NameOne", "pihS TSET", WdbRecordDataType.StringType)
                },
                new object[]
                {
                    _gameObjectCacheReader,
                    21351,
                    new WdbRecordOptions()
                    {
                        Name = "Identifier",
                        DataType = WdbRecordDataType.IntegerType,
                        IsReversed = false,
                        Length = 4
                    },
                    new WdbRecord("Identifier", 171546u, WdbRecordDataType.IntegerType)
                },
                new object[]
                {
                    _gameObjectCacheReader,
                    112,
                    new WdbRecordOptions()
                    {
                        Name = "Flags",
                        DataType = WdbRecordDataType.BitMaskType,
                        IsReversed = false,
                        Length = 4
                    },
                    new WdbRecord("Flags", new byte[] { 0, 0, 0, 0 }, WdbRecordDataType.BitMaskType)
                },
                new object[]
                {
                    _itemCacheReader,
                    272,
                    new WdbRecordOptions()
                    {
                        Name = "Damage1Min",
                        DataType = WdbRecordDataType.FloatType,
                        IsReversed = false,
                        Length = 4
                    },
                    new WdbRecord("Damage1Min", 0f, WdbRecordDataType.FloatType)
                }
            };

        /// <summary>
        /// Gets the wdb record empty data type data.
        /// </summary>
        public static IEnumerable<object[]> WdbRecordEmptyDataTypeData =>
            new[]
            {
                new object[]
                {
                    _gameObjectCacheReader,
                    0,
                    new WdbRecordOptions()
                    {
                        Name = "Signature",
                        DataType = (WdbRecordDataType)5,
                        IsReversed = true,
                        Length = 4
                    },
                    new WdbRecord("Signature", null, (WdbRecordDataType)5)
                }
            };

        /// <summary>
        /// Gets the wdb records data.
        /// </summary>
        /// <remarks>
        /// Contains arrays containing the <see cref="BinaryReader"/> for the file to test on, the
        /// <see cref="int"/> position of the record struct to find and the <see
        /// cref="WdbStructOptions"/> for the record struct.
        /// </remarks>
        public static IEnumerable<object[]> WdbRecordsData =>
            new[]
            {
                new object[]
                {
                    _gameObjectCacheReader,
                    0,
                    OptionsHelper.GameObjectCacheOptions.HeaderOptions
                },
                new object[] { _gameObjectCacheReader, 20, OptionsHelper.GameObjectCacheOptions },
                new object[] { _itemCacheReader, 0, OptionsHelper.ItemCacheOptions.HeaderOptions },
                new object[] { _itemCacheReader, 20, OptionsHelper.ItemCacheOptions },
            };

        #endregion Properties
    }
}
