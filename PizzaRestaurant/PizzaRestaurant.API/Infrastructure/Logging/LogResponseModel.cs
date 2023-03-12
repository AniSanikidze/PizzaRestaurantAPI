namespace PizzaRestaurant.API.Infrastructure.Logging
{
    public class LogResponseModel
    {
        public int StatusCode { get; set; }
        public string ContentType { get; set; }
        public string Body { get; set; }
        public IHeaderDictionary Headers { get; set; }
        public DateTime ResponseTime => DateTime.Now;
    }
}
