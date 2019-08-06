using System.ComponentModel.DataAnnotations;

namespace Musaca.Models
{
    public class Product
    {
        public string Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }
    }
}
