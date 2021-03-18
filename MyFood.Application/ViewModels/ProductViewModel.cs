using System;
using System.ComponentModel.DataAnnotations;

namespace MyFood.Application.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
