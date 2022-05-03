using System.Collections.Generic;

namespace models
{
    public class Seller
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }

        public virtual User User { get; set; }
    }
}
