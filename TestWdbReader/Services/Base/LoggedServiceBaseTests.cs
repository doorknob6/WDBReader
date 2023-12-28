using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using WdbReader.Services.Base;

namespace TestWdbReader.Services.Base
{
    [TestClass]
    public class LoggedServiceBaseTests
    {
        #region TestClass

        private class LoggedServiceBaseTest : LoggedServiceBase
        {
            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="LoggedServiceBaseTest"/> class.
            /// </summary>
            /// <param name="logger">The logger.</param>
            public LoggedServiceBaseTest(ILogger<LoggedServiceBaseTest> logger)
                : base(logger) { }

            #endregion Constructors

            #region Properties

            /// <summary>
            /// Gets the test logger.
            /// </summary>
            public ILogger TestLogger => Logger;

            #endregion Properties
        }

        #endregion TestClass

        [TestMethod]
        public void TestObjectDisposed()
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(
                (builder) => builder.AddProvider(new DebugLoggerProvider())
            );
            ILogger<LoggedServiceBaseTest> logger =
                loggerFactory.CreateLogger<LoggedServiceBaseTest>();

            LoggedServiceBaseTest loggedServiceBaseTest = new(logger);

            loggedServiceBaseTest.Dispose();

            Assert.ThrowsException<ObjectDisposedException>(
                () => loggedServiceBaseTest.TestLogger.LogDebug("test")
            );
        }
    }
}
