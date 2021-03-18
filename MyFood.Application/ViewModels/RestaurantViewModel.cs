using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFood.Application.ViewModels
{
    public class RestaurantViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public Guid ExpertiseId { get; set; }
        public AddressViewModel Address { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
