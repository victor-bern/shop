﻿namespace Backend.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

        public double PromocionalPrice { get; set; }
        public string Image { get; set; }
    }
}
