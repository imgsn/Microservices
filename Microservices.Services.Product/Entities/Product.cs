﻿using System.ComponentModel.DataAnnotations;

namespace Microservices.Services.Product.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string Description { get; set; }

        [Range(1, 1000)]
        public double Price { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

    }
}
