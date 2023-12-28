using TestWdbReader.Helpers;
using WdbReader.Model;
using WdbReader.Model.Exceptions;
using WdbReader.Options;
using WdbReader.Services.Contracts;
using WdbReader.Services.Exceptions;

namespace TestWdbReader.Services
{
    [TestClass]
    public class WdbRecordServiceTests
    {
        #region Fields

        private IWdbRecordService? _service;

        #endregion Fields

        #region Initialization

        [TestInitialize]
        public void Setup()
        {
            _service = ServiceHelper.GetRequiredService<IWdbRecordService>();
        }

        #endregion Initialization

        #region Tests

        #region GetRecord

        [TestMethod]
        public void GetRecord_RecordIsNotPresent_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            List<WdbRecord> records =
                new()
                {
                    new WdbRecord("Signature", "WGOB", WdbRecordDataType.StringType),
                    new WdbRecord("Identifier", 20808u, WdbRecordDataType.IntegerType)
                };
            string name = "NameOne";

            // Act
            Assert.ThrowsException<WdbRecordNotFoundException>(
                () => service.GetRecord(records, name)
            );
        }

        [TestMethod]
        public void GetRecord_RecordIsPresent_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            WdbRecord expected = new("NameOne", "TEST Ship", WdbRecordDataType.StringType);
            List<WdbRecord> records =
                new()
                {
                    new WdbRecord("Signature", "WGOB", WdbRecordDataType.StringType),
                    new WdbRecord("Identifier", 20808u, WdbRecordDataType.IntegerType),
                    expected
                };
            string name = "NameOne";

            // Act
            WdbRecord result = service.GetRecord(records, name);

            // Assert
            Assert.AreEqual(expected, result);
        }

        #endregion GetRecord

        #region GetRecords

        [TestMethod]
        [DynamicData(nameof(TestFileHelper.WdbRecordsData), typeof(TestFileHelper))]
        public void GetRecords_Pass(BinaryReader wdbReader, int position, WdbStructOptions options)
        {
            // Arrange
            wdbReader.BaseStream.Position = position;
            IWdbRecordService service = GetService();
            int expectedLength = options.RecordOptions.Count;

            // Act
            List<WdbRecord>? result = service.GetRecords(wdbReader, options);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedLength, result.Count);
            int i = 0;
            foreach (WdbRecordOptions option in options.RecordOptions)
            {
                Assert.AreEqual(option.Name, result[i++].Name);
            }
        }

        #endregion GetRecords

        #region GetRecordValueFloatNotNull

        [TestMethod]
        public void GetRecordValueFloatNotNull_RecordIsNotPresent_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "Damage1Min";

            List<WdbRecord> records =
                new()
                {
                    new WdbRecord("Signature", "WGOB", WdbRecordDataType.StringType),
                    new WdbRecord("Identifier", 20808u, WdbRecordDataType.IntegerType)
                };

            // Act
            Assert.ThrowsException<WdbRecordNotFoundException>(
                () => service.GetRecordValueFloatNotNull(records, name)
            );
        }

        [TestMethod]
        public void GetRecordValueFloatNotNull_RecordIsPresentNotFloat_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "Damage1Min";
            object? expected = null;
            WdbRecord expectedRecord = new(name, expected, WdbRecordDataType.StringType);
            List<WdbRecord> records =
                new()
                {
                    new WdbRecord("Signature", "WGOB", WdbRecordDataType.StringType),
                    new WdbRecord("Identifier", 20808u, WdbRecordDataType.IntegerType),
                    expectedRecord
                };

            // Act
            Assert.ThrowsException<WdbRecordValueTypeException>(
                () => service.GetRecordValueFloatNotNull(records, name)
            );
        }

        [TestMethod]
        public void GetRecordValueFloatNotNull_RecordIsPresentNotNull_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "Damage1Min";
            float expected = 68f;
            WdbRecord expectedRecord = new(name, expected, WdbRecordDataType.FloatType);
            List<WdbRecord> records =
                new()
                {
                    new WdbRecord("Signature", "WGOB", WdbRecordDataType.StringType),
                    new WdbRecord("Identifier", 20808u, WdbRecordDataType.IntegerType),
                    expectedRecord
                };

            // Act
            float result = service.GetRecordValueFloatNotNull(records, name);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetRecordValueFloatNotNull_RecordIsPresentNull_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "Damage1Min";
            float? expected = null;
            WdbRecord expectedRecord = new(name, expected, WdbRecordDataType.FloatType);
            List<WdbRecord> records =
                new()
                {
                    new WdbRecord("Signature", "WGOB", WdbRecordDataType.StringType),
                    new WdbRecord("Identifier", 20808u, WdbRecordDataType.IntegerType),
                    expectedRecord
                };

            // Act
            Assert.ThrowsException<WdbRecordValueNullException>(
                () => service.GetRecordValueFloatNotNull(records, name)
            );
        }

        [TestMethod]
        public void GetRecordValueFloatNotNull_ValueNotFloat_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "Description";
            string? expected = "";
            WdbRecord record = new(name, expected, WdbRecordDataType.StringType);

            // Act
            Assert.ThrowsException<WdbRecordValueTypeException>(
                () => service.GetRecordValueFloatNotNull(record)
            );
        }

        [TestMethod]
        public void GetRecordValueFloatNotNull_ValueNotNull_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "Damage1Min";
            float? expected = 68f;
            WdbRecord record = new(name, expected, WdbRecordDataType.FloatType);

            // Act
            float result = service.GetRecordValueFloatNotNull(record);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetRecordValueFloatNotNull_ValueNull_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "Damage1Min";
            float? expected = null;
            WdbRecord record = new(name, expected, WdbRecordDataType.FloatType);

            // Act
            Assert.ThrowsException<WdbRecordValueNullException>(
                () => service.GetRecordValueFloatNotNull(record)
            );
        }

        #endregion GetRecordValueFloatNotNull

        #region GetRecordValueIntNotNull

        [TestMethod]
        public void GetRecordValueIntNotNull_RecordIsNotPresent_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "WeaponDelay";

            List<WdbRecord> records =
                new()
                {
                    new WdbRecord("Signature", "WGOB", WdbRecordDataType.StringType),
                    new WdbRecord("Identifier", 20808u, WdbRecordDataType.IntegerType)
                };

            // Act
            Assert.ThrowsException<WdbRecordNotFoundException>(
                () => service.GetRecordValueIntNotNull(records, name)
            );
        }

        [TestMethod]
        public void GetRecordValueIntNotNull_RecordIsPresentNotInt_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "WeaponDelay";
            object? expected = null;
            WdbRecord expectedRecord = new(name, expected, WdbRecordDataType.StringType);
            List<WdbRecord> records =
                new()
                {
                    new WdbRecord("Signature", "WGOB", WdbRecordDataType.StringType),
                    new WdbRecord("Identifier", 20808u, WdbRecordDataType.IntegerType),
                    expectedRecord
                };

            // Act
            Assert.ThrowsException<WdbRecordValueTypeException>(
                () => service.GetRecordValueIntNotNull(records, name)
            );
        }

        [TestMethod]
        public void GetRecordValueIntNotNull_RecordIsPresentNotNull_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "WeaponDelay";
            uint expected = 6500u;
            WdbRecord expectedRecord = new(name, expected, WdbRecordDataType.IntegerType);
            List<WdbRecord> records =
                new()
                {
                    new WdbRecord("Signature", "WGOB", WdbRecordDataType.StringType),
                    new WdbRecord("Identifier", 20808u, WdbRecordDataType.IntegerType),
                    expectedRecord
                };

            // Act
            uint result = service.GetRecordValueIntNotNull(records, name);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetRecordValueIntNotNull_RecordIsPresentNull_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "WeaponDelay";
            uint? expected = null;
            WdbRecord expectedRecord = new(name, expected, WdbRecordDataType.IntegerType);
            List<WdbRecord> records =
                new()
                {
                    new WdbRecord("Signature", "WGOB", WdbRecordDataType.StringType),
                    new WdbRecord("Identifier", 20808u, WdbRecordDataType.IntegerType),
                    expectedRecord
                };

            // Act
            Assert.ThrowsException<WdbRecordValueNullException>(
                () => service.GetRecordValueIntNotNull(records, name)
            );
        }

        [TestMethod]
        public void GetRecordValueIntNotNull_ValueNotInt_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "Description";
            string? expected = "";
            WdbRecord record = new(name, expected, WdbRecordDataType.StringType);

            // Act
            Assert.ThrowsException<WdbRecordValueTypeException>(
                () => service.GetRecordValueIntNotNull(record)
            );
        }

        [TestMethod]
        public void GetRecordValueIntNotNull_ValueNotNull_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "WeaponDelay";
            uint? expected = 6500u;
            WdbRecord record = new(name, expected, WdbRecordDataType.IntegerType);

            // Act
            uint result = service.GetRecordValueIntNotNull(record);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetRecordValueIntNotNull_ValueNull_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "WeaponDelay";
            uint? expected = null;
            WdbRecord record = new(name, expected, WdbRecordDataType.IntegerType);

            // Act
            Assert.ThrowsException<WdbRecordValueNullException>(
                () => service.GetRecordValueIntNotNull(record)
            );
        }

        #endregion GetRecordValueIntNotNull

        #region GetRecordValueStringNotNull

        [TestMethod]
        public void GetRecordValueStringNotNull_RecordIsNotPresent_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "Description";

            List<WdbRecord> records =
                new()
                {
                    new WdbRecord("Signature", "WGOB", WdbRecordDataType.StringType),
                    new WdbRecord("Identifier", 20808u, WdbRecordDataType.StringType)
                };

            // Act
            Assert.ThrowsException<WdbRecordNotFoundException>(
                () => service.GetRecordValueStringNotNull(records, name)
            );
        }

        [TestMethod]
        public void GetRecordValueStringNotNull_RecordIsPresentNotNull_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "Description";
            string expected = "test";
            WdbRecord expectedRecord = new(name, expected, WdbRecordDataType.StringType);
            List<WdbRecord> records =
                new()
                {
                    new WdbRecord("Signature", "WGOB", WdbRecordDataType.StringType),
                    new WdbRecord("Identifier", 20808u, WdbRecordDataType.StringType),
                    expectedRecord
                };

            // Act
            string result = service.GetRecordValueStringNotNull(records, name);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetRecordValueStringNotNull_RecordIsPresentNotString_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "WeaponDelay";
            object? expected = 6500u;
            WdbRecord expectedRecord = new(name, expected, WdbRecordDataType.IntegerType);
            List<WdbRecord> records =
                new()
                {
                    new WdbRecord("Signature", "WGOB", WdbRecordDataType.StringType),
                    new WdbRecord("Identifier", 20808u, WdbRecordDataType.StringType),
                    expectedRecord
                };

            // Act
            Assert.ThrowsException<WdbRecordValueTypeException>(
                () => service.GetRecordValueStringNotNull(records, name)
            );
        }

        [TestMethod]
        public void GetRecordValueStringNotNull_RecordIsPresentNull_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "Description";
            string? expected = null;
            WdbRecord expectedRecord = new(name, expected, WdbRecordDataType.StringType);
            List<WdbRecord> records =
                new()
                {
                    new WdbRecord("Signature", "WGOB", WdbRecordDataType.StringType),
                    new WdbRecord("Identifier", 20808u, WdbRecordDataType.StringType),
                    expectedRecord
                };

            // Act
            Assert.ThrowsException<WdbRecordValueNullException>(
                () => service.GetRecordValueStringNotNull(records, name)
            );
        }

        [TestMethod]
        public void GetRecordValueStringNotNull_ValueNotNull_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "Description";
            string? expected = "test";
            WdbRecord record = new(name, expected, WdbRecordDataType.StringType);

            // Act
            string result = service.GetRecordValueStringNotNull(record);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetRecordValueStringNotNull_ValueNotString_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "WeaponDelay";
            object? expected = 6500u;
            WdbRecord record = new(name, expected, WdbRecordDataType.IntegerType);

            // Act
            Assert.ThrowsException<WdbRecordValueTypeException>(
                () => service.GetRecordValueStringNotNull(record)
            );
        }

        [TestMethod]
        public void GetRecordValueStringNotNull_ValueNull_Pass()
        {
            // Arrange
            IWdbRecordService service = GetService();
            string name = "Description";
            string? expected = null;
            WdbRecord record = new(name, expected, WdbRecordDataType.StringType);

            // Act
            Assert.ThrowsException<WdbRecordValueNullException>(
                () => service.GetRecordValueStringNotNull(record)
            );
        }

        #endregion GetRecordValueStringNotNull

        #endregion Tests

        #region Accessors

        private IWdbRecordService GetService()
        {
            Assert.IsNotNull(_service);
            return _service;
        }

        #endregion Accessors
    }
}
