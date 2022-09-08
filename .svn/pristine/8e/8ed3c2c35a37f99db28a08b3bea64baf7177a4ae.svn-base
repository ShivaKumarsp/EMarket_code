
using EMarket.Service.Logging;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;
using System;

namespace EMarket.Service
{
    class EMarketLogger : IEMarketLogger
    {
        private readonly ILogger _logger;
        private readonly LoggerType _loggerType;
        private readonly TelemetryClient _client;
      

        public void TrackException(Exception exception, string message)
        {
            _client.TrackException(exception);
            _client.Flush();
        }

        public void TrackInfo(string message)
        {
            _client.TrackTrace(message);
            _client.Flush();
        }

        public void TrackWarning(string message)
        {
            _client.TrackTrace(message);
            _client.Flush();
        }

        public void DebugLog(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
