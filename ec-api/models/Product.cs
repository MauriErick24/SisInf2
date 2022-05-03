using System;

namespace models
{
    public class Product
    {
        public int? Id { get; set; }

        public int? SellerId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
