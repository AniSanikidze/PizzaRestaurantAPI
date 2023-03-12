using PizzaRestaurant.API.Infrastructure.Logging;

namespace PizzaRestaurant.API.Infrastructure.Middlewares
{
    public class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate next;

        public ResponseLoggingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            Stream originalBody = context.Response.Body;

            try
            {
                using (var memStream = new MemoryStream())
                {
                    context.Response.Body = memStream;

                    await next(context);

                    await LogResponse(context.Response, memStream);

                    memStream.Position = 0;
                    await memStream.CopyToAsync(originalBody);
                }
            }
            finally
            {
                context.Response.Body = originalBody;
            }

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
            var completePath = Directory.GetCurrentDirectory() + "\\Infrastructure\\Logging\\Logs.txt";
            await File.AppendAllTextAsync(completePath, logInfo);
        }
    }
}
