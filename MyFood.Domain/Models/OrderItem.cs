using MyFood.Domain.Core.Models;
using System;

namespace MyFood.Domain.Models
{
    public class OrderItem : Entity
    {
        public OrderItem(Guid id, Guid productId, int unit, decimal discount)
        {
            Id = id;
            ProductId = productId;
            Unit = unit;
            Discount = discount;
        }

        protected OrderItem() { }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public int Unit { get; set; }
        public decimal Discount { get; set; }
    }
}
