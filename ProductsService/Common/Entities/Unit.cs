﻿namespace ProductsService.Common.Entities
{
    public class Unit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
