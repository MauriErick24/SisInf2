namespace models
{
    using System.ComponentModel.DataAnnotations;

    public class Dessert
    {
        public int? Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
