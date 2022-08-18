using System.ComponentModel.DataAnnotations;

namespace Bakery.Product.DomainApi
{
    public class BaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
