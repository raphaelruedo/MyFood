using System;
using System.ComponentModel.DataAnnotations;

namespace MyFood.Application.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public Guid id { get; set; }

        public string Name { get; set; }
    }
}
