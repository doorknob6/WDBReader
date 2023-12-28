using Microsoft.Extensions.Logging;

namespace WdbReader.Services.Base
{
    /// <summary>
    /// The logged service base.
    /// </summary>
    public abstract class LoggedServiceBase : IDisposable
    {
        #region Fields

        private bool _disposedValue;
        private ILogger? _logger;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggedServiceBase"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        protected LoggedServiceBase(ILogger logger)
        {
            _logger = logger;

            Logger.LogInformation("{Service} initialised", ToString());
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the logger.
        /// </summary>
        protected ILogger Logger => _logger ?? throw new ObjectDisposedException(ToString());

        #endregion Properties

        #region Disposable

        /// <inheritdoc/>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Free manage objects if the object is disposing
        /// </summary>
        /// <param name="disposing">If true, disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Logger.LogInformation("{Service} is disposing", ToString());
                    _logger = null;
                }
                _disposedValue = true;
            }
        }

        #endregion Disposable
    }
}
