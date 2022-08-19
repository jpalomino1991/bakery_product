using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bakery.Product.DomainApi.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public long Price { get; set; }

        public int ExpirationDays { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string User { get; set; }
    }
}
