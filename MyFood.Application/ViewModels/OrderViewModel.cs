using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFood.Application.ViewModels
{
    public class OrderViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Observation { get; set; }
        public List<OrderItemViewModel> OrderItens { get; set; }
        public Guid UserId { get; set; }
        public AddressViewModel Address { get; set; }
        public Guid OrderStatusId { get; set; }

        [JsonIgnore]
        public Guid AddressId { get; set; }

        [JsonIgnore]
        public OrderStatusViewModel OrderStatus { get; set; }
    }
}
