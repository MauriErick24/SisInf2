using System;

namespace models
{
    public class User
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
