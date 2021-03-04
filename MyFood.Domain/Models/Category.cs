using MyFood.Domain.Core.Models;
using System.Collections.Generic;

namespace MyFood.Domain.Models
{
    public class Category : Entity
    {
        public Category(string name)
        {
            Name = name;
        }

        protected Category() { }

    
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
