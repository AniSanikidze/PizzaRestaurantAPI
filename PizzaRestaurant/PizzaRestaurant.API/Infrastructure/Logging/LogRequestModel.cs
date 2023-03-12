﻿namespace PizzaRestaurant.API.Infrastructure.Logging
{
    public class LogRequestModel
    {
        public string IP { get; set; }
        public string Scheme { get; set; }
        public string Host { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public string Body { get; set; }
        public bool IsSecured { get; set; }
        public DateTime RequestTime => DateTime.Now;
    }
}
