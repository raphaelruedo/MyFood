using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyFood.Application.ViewModels
{
    public class OrderItemViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Unit { get; set; }
        public decimal Discount { get; set; }
       
        [JsonIgnore]
        public ProductViewModel Product { get; set; }

        [JsonIgnore]
        public OrderViewModel Order { get; set; }
    }
}
