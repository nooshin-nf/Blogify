namespace Blogify.Gateway.DelegatingHandlers;
public class LoggingDelegatingHandler : DelegatingHandler
{
    private readonly ILogger<LoggingDelegatingHandler> _logger;

    public LoggingDelegatingHandler(ILogger<LoggingDelegatingHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Log the HTTP request details
        _logger.LogInformation("Sending request to {Url}", request.RequestUri);
        _logger.LogInformation("Request Method: {Method}", request.Method);
        _logger.LogInformation("Request Headers: {Headers}", request.Headers.ToString());

        // Send the request to the next handler in the chain (or the downstream service)
        var response = await base.SendAsync(request, cancellationToken);

        // Log the HTTP response details
        _logger.LogInformation("Received response from {Url} with status code {StatusCode}", request.RequestUri, response.StatusCode);

        return response;
    }
}
