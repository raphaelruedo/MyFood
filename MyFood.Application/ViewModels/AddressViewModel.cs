using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFood.Application.ViewModels
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string ZipCode { get; set; }

        [JsonIgnore]
        public List<RestaurantViewModel> Restaurants { get; set; }

        [JsonIgnore]
        public List<OrderViewModel> Orders { get; set; }
    }
}
