using Microsoft.Extensions.Logging;
using Prometheus;
using System;

namespace AspnetCore.Healthchecks.Metrics.Api.Metrics
{
    public class MetricReporter
    {
        private readonly ILogger<MetricReporter> _logger;
        private readonly Counter _requestCounter;
        private readonly Histogram _responseTimeHistogram;

        public MetricReporter(ILogger<MetricReporter> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _requestCounter =
                Prometheus.Metrics.CreateCounter("total_requests", "The total number of requests serviced by this API.", new CounterConfiguration
                {
                    LabelNames = new[] { "method", "endpoint" }
                });

            _responseTimeHistogram = Prometheus.Metrics.CreateHistogram("request_duration_seconds",
                "The duration in seconds between the response to a request.", new HistogramConfiguration
                {
                    Buckets = Histogram.ExponentialBuckets(0.01, 2, 10),
                    LabelNames = new[] { "status_code", "method", "endpoint" }
                });
        }

        public void RegisterRequest()
        {
            _requestCounter.Inc();
        }

        public void RegisterResponseTime(int statusCode, string method, string endpoint, TimeSpan elapsed)
        {
            _responseTimeHistogram.Labels(statusCode.ToString(), method, endpoint).Observe(elapsed.TotalSeconds);
        }
    }

}
