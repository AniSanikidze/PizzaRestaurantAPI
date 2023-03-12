using PizzaRestaurant.API.Infrastructure.Logging;
using System.Text;

namespace PizzaRestaurant.API.Infrastructure.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await LogRequest(httpContext.Request);

            Stream originalBody = httpContext.Response.Body;

            try
            {
                using (var memStream = new MemoryStream())
                {
                    httpContext.Response.Body = memStream;

                    await _next(httpContext);

                    await LogResponse(httpContext.Response, memStream);

                    memStream.Position = 0;
                    await memStream.CopyToAsync(originalBody);
                }
            }
            finally
            {
                httpContext.Response.Body = originalBody;
            }
        }

        public async Task LogRequest(HttpRequest httpRequest)
        {
            var request = new LogRequestModel
            {
                IP = httpRequest.HttpContext.Connection.RemoteIpAddress.ToString(),
                Scheme = httpRequest.Scheme,
                Host = httpRequest.Host.ToString(),
                IsSecured = httpRequest.IsHttps,
                Method = httpRequest.Method,
                QueryString = httpRequest.QueryString.ToString(),
                Path = httpRequest.Path,
                Body = await ReadRequestBody(httpRequest)
            };

            var logInfo = $"{Environment.NewLine}*******Request Log*******{Environment.NewLine}" +
                $"IP = {request.IP}{Environment.NewLine}" +
                $"Scheme = {request.Scheme}{Environment.NewLine}" +
                $"Host = {request.Host}{Environment.NewLine}" +
                $"IsSecured = {request.IsSecured}{Environment.NewLine}" +
                $"Method = {request.Method}{Environment.NewLine}" +
                $"Query String = {request.QueryString}{Environment.NewLine}" +
                $"Path = {request.Path}{Environment.NewLine}" +
                $"Body = {request.Body}{Environment.NewLine}" +
                $"Request Time = {request.RequestTime}{Environment.NewLine}";


            var completePath = Directory.GetCurrentDirectory() + "\\Infrastructure\\Logging\\Logs.txt";
            await File.AppendAllTextAsync(completePath, logInfo);

        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            request.EnableBuffering();
            var buffer = new byte[request.ContentLength ?? 0];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body.Position = 0;
            return bodyAsText;
        }
        public async Task LogResponse(HttpResponse httpResponse, MemoryStream memStream)
        {
            memStream.Position = 0;
            string responseBody = new StreamReader(memStream).ReadToEnd();
            Console.WriteLine(responseBody);

            var response = new LogResponseModel
            {
                Body = responseBody,
                ContentType = httpResponse.ContentType,
                StatusCode = httpResponse.StatusCode,
                Headers = httpResponse.Headers
            };

            var logInfo = $"{Environment.NewLine}*******Response Log*******{Environment.NewLine}" +
                $"Content type = {response.ContentType}{Environment.NewLine}" +
                $"Status code = {response.StatusCode}{Environment.NewLine}" +
                $"Body = {response.Body}{Environment.NewLine}" +
                $"Headers = ";

            response.Headers.ToList().ForEach(header => logInfo += $"{header.Key}:{header.Value}\n");
            logInfo += $"{Environment.NewLine}";
            var completePath = Directory.GetCurrentDirectory() + "\\Infrastructure\\Logging\\Logs.txt";
            await File.AppendAllTextAsync(completePath, logInfo);
        }
    }
}
