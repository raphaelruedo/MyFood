using MyFood.Domain.Core.Models;
using System.Collections.Generic;

namespace MyFood.Domain.Models
{
    public class Expertise : Entity
    {
        public Expertise(string name)
        {
            Name = name;
        }

        protected Expertise() { }

        public string Name { get; set; }

        public List<Restaurant> Restaurants { get; set; }
    }
}
