using MyFood.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace MyFood.Domain.Models
{
    public class Address : Entity
    {
        public Address(Guid id, string street, int number, string complement,
                        string city, string district, string country,
                        double longitude, double latitude, string zipCode)
        {
            Id = id;
            Street = street;
            Number = number;
            Complement = complement;
            City = city;
            District = district;
            Country = country;
            Longitude = longitude;
            Latitude = latitude;
            ZipCode = zipCode;
        }


        protected Address() { }

        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string ZipCode { get; set; }

        public List<Restaurant> Restaurants { get; set; }

        public List<Order> Orders { get; set; }
    }
}
