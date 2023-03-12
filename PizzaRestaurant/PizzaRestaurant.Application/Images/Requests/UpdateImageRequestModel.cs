﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Application.Images.Requests
{
    public class UpdateImageRequestModel
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public string OriginalName { get; set; }
        public string Path { get; set; }
        public int ImageId { get; set; }
    }
}
